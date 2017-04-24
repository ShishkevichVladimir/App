using System;
using System.Linq;
using App.BL;
using App.Models;
using App.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IMessageService _messageService = new MessageService(new FakeRepository());

        [TestMethod]
        public void SendMessasge()
        {
            // arrange
            var msg = new Message
            {
                Text = "test"
            };
            var userName = "bob";

            // act
            _messageService.Send(userName, msg);

            // assert
            var messages = _messageService.GetMessagesByUserName(userName);
            var hasMessage = messages.Any(t => t.Text.Equals(msg.Text, StringComparison.CurrentCulture));

            Assert.IsTrue(hasMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void SendMessasgeToUndefinedUser()
        {
            // arrange
            var msg = new Message
            {
                Text = "test"
            };
            var userName = "undefined";

            // act
            _messageService.Send(userName, msg);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SendMoreThanFiveMessasges()
        {
            // arrange
            var msg = new Message
            {
                Text = "test"
            };
            var userName = "bob2";
            var messageCount = 10;
            
            for (int i = 0; i < messageCount; i++)
            {
                // act
               _messageService.Send(userName, msg);
            }
        }
    }
}
