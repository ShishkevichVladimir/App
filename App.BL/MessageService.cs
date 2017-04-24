using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App.EF;
using App.Models;
using App.Repository;

[assembly: InternalsVisibleTo("App.Tests")]
[assembly: InternalsVisibleTo("App.Console")]

namespace App.BL
{


    internal class MessageService : IMessageService
    {
        private readonly IRepository _repository;
        private const int MaxAllowedMessageCount = 5;

        public MessageService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddNewUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            _repository.AddUser(new User
            {
                Name = userName
            });
            _repository.Commit();
        }

        public void Send(string userName, Message message)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var user = _repository.GetUserByName(userName);
            if (user == null)
            {
                throw new UserNotFoundException($"не найден пользователь с именеем = {userName}");
            }

            var dateNow = DateTime.Now;
            var todayMessageCount = user.Messages.Count(msg => msg.CreatedDate.Day == dateNow.Day && msg.CreatedDate.Month == dateNow.Month && msg.CreatedDate.Year == dateNow.Year);
            if (todayMessageCount > MaxAllowedMessageCount)
            {
                throw new InvalidOperationException("На сегодня превышен лимит по отправке сообщений.");
            }

            user.Messages.Add(message);
            _repository.Commit();
        }

        public Message[] GetMessagesByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            var user = _repository.GetUserByName(userName);
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            return user.Messages.ToArray();
        }
    }
}
