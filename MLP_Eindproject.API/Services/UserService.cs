using Microsoft.Extensions.Configuration;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class UserService : IUserService
    {
        private readonly MLPDbContext _context;
        private readonly string hmacsha256Key;
        private readonly string aesKey;
        public UserService(MLPDbContext context, IConfiguration configuration)
        {
            _context = context;
            hmacsha256Key = configuration.GetSection("Keys").GetSection("HMACSHA256").Value;
            aesKey = configuration.GetSection("Keys").GetSection("Aes").Value;
        }
        public string EncryptTokenForAuthentication(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var iv = new byte[16];
            
            var dateTime = DateTime.Now.ToString("yyyy/MM/dd-HH:mm:ss:ffff");
            var original = $"{id};{dateTime}";

            byte[] encrypted;
            using (Aes myAes = Aes.Create())
            {
                myAes.Key = Encoding.UTF8.GetBytes(aesKey);
                myAes.IV = iv;
                var encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(original);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }var token = Convert.ToBase64String(encrypted);            
            return token;
        }
        public string DecryptTokenForAuthentication(string token)
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            var iv = new byte[16];
            
            var buffer = Convert.FromBase64String(token);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(aesKey);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public string HashForRegistrationAndLogin(string token)
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            
            var encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(token);
            Byte[] keyBytes = encoding.GetBytes(hmacsha256Key);
            Byte[] hashBytes;
            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(textBytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
        public async Task AddAdminToDb(Admin admin)
        {
            if (admin is null)
            {
                throw new ArgumentNullException(nameof(admin));
            }

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }
        public async Task AddTeacherToDb(Teacher teacher)
        {
            if (teacher is null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudentToDb(Student student)
        {
            if (student is null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public int? GetUserFromDb(string email, string password)
        {
            if (email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            int? user = null;
            var teacher = _context.Teachers.Where(x => x.Email == email & x.Password == password).FirstOrDefault();
            if(teacher is not null) { user = teacher.Id; }
            var student = _context.Students.Where(x => x.Email == email & x.Password == password).FirstOrDefault();
            if (student is not null) { user = student.Id; }
            var admin = _context.Admins.Where(x => x.Email == email & x.Password == password).FirstOrDefault();
            if(admin is not null) { user = admin.Id; }
            return user;

        }

        public async Task AddTokenToUser(int? id, string token)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            var teacher = _context.Teachers.Find(id);
            if(teacher is not null) { teacher.Token = token; }
            var student = _context.Students.Find(id);
            if(student is not null) { student.Token = token; }
            var admin = _context.Admins.Find(id);
            if(admin is not null){ admin.Token = token; }
            
            await _context.SaveChangesAsync();
        }

        public bool UserExistanceByToken(string token)
        {
            bool userExists = false;
            var teacher = _context.Teachers.FirstOrDefault(x => x.Token == token);
            if(teacher is not null) { userExists = true; }
            var student = _context.Students.FirstOrDefault(x => x.Token == token);
            if(student is not null) { userExists = true; }
            var admin = _context.Admins.FirstOrDefault(x => x.Token == token);
            if(admin is not null) { userExists = true; };
            return userExists;
        }

        public async Task LogUserOut(string token)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Token == token);
            if (teacher is not null) { teacher.Token = null; }
            var student = _context.Students.FirstOrDefault(x => x.Token == token);
            if (student is not null) { student.Token = null; }
            var admin = _context.Admins.FirstOrDefault(x => x.Token == token);
            if (admin is not null) { admin.Token = null; };
            await _context.SaveChangesAsync();
        }

        public bool CheckEmailAvailability(string email)
        {
            bool emailIsNotAvailable = false;
            emailIsNotAvailable = _context.Admins.Any(x => x.Email == email);
            if(emailIsNotAvailable is true) { return emailIsNotAvailable; }
            emailIsNotAvailable = _context.Teachers.Any(x => x.Email == email);
            if (emailIsNotAvailable is true) { return emailIsNotAvailable; }
            emailIsNotAvailable = _context.Students.Any(x => x.Email == email);
            return emailIsNotAvailable;
        }

        public PersonType GetPersonType(int id)
        {
            var admin = _context.Admins.Find(id);
            if(admin is not null) { return PersonType.Admin; }
            var teacher = _context.Teachers.Find(id);
            if (teacher is not null) { return PersonType.Teacher; } 
            else { return PersonType.Student; }
        }
    }
}
