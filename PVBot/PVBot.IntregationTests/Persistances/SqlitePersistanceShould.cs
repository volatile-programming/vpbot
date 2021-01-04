using System;
using System.Collections.Generic;
using System.Text;
using DryIoc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PVBot.Application.Mock.Models;
using PVBot.Clients.UI.Persistences;
using PVBot.DataObjects.Contracts.Core;
using PVBot.DataObjects.Models;
using SQLite;

namespace PVBot.IntregationTests
{
    // [TestClass]
    public class SqlitePersistanceShould
    {
        private IPersistence<TextMessage> _sut;

        [TestInitialize]
        public void Inizialize()
        {
            var container = Assembly.Container;
            _sut = (IPersistence<TextMessage>)container.Resolve(typeof(IPersistence<TextMessage>));
        }

        [TestMethod]
        public void CreateAndReadEntity()
        {
            _sut.Add(MockObjects.Message);
            TextMessage newMessage = _sut.Find(x => x.Date == MockObjects.Message.Date);
            MockObjects.Message.Id = newMessage.Id;

            newMessage.Should().NotBeNull();
            newMessage.Should().BeEquivalentTo(MockObjects.Message);
        }

        [TestMethod]
        public void UpdateEntity()
        {
            _sut.Add(MockObjects.Message);
            TextMessage newMessage = _sut.Find(x => x.Date == MockObjects.Message.Date);

            MockObjects.Message.Id = newMessage.Id;
            MockObjects.Message.From = newMessage.To;
            MockObjects.Message.To = newMessage.From;

            _sut.Update(MockObjects.Message);
            TextMessage updatedMessage = _sut.Find(x => x.Id == MockObjects.Message.Id);

            newMessage.Should().NotBeNull();
            updatedMessage.Should().NotBeNull();
            updatedMessage.Should().NotBeEquivalentTo(newMessage);
            updatedMessage.Should().BeEquivalentTo(MockObjects.Message);
        }

        [TestMethod]
        public void DeleteEntity()
        {
            _sut.Add(MockObjects.Message);
            TextMessage newMessage = _sut.Find(x => x.Date == MockObjects.Message.Date);
            MockObjects.Message.Id = newMessage.Id;

            newMessage.Should().NotBeNull();
            newMessage.Should().BeEquivalentTo(MockObjects.Message);

            _sut.Remove(MockObjects.Message);
        }
    }
}
