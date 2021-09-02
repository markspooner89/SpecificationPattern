using Code.Data;
using Code.Objects;
using Code.Services;
using Code.Specifications;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class ToDoItemServiceTests
    {
        private readonly IToDoItemRepository _repository;

        public ToDoItemServiceTests()
        {
            var mockRepo = new Mock<IToDoItemRepository>();

            mockRepo
                .Setup(repo => repo.GetToDoItems())
                .Returns(new List<ToDoItem>
                {
                    new ToDoItem(1, "Todo 1", false, DateTime.Now.AddDays(2)),
                    new ToDoItem(2, "Todo 2", false, DateTime.Now.AddDays(2)),
                    new ToDoItem(3, "Todo 3", true, DateTime.Now.AddDays(2)),
                    new ToDoItem(4, "Todo 4", true, DateTime.Now.AddDays(-2)),
                    new ToDoItem(1, "Todo 5", false, DateTime.Now.AddDays(-1))
                });

            _repository = mockRepo.Object;
        }

        [Fact]
        public void ReturnOnlyCompleteItems()
        {
            var specs = new List<ISpecification<ToDoItem>>
            {
                new IsCompleteSpecification(true)
            };

            var service = new ToDoItemService(_repository);

            var items = service.GetToDoItems(specs);

            Assert.All(items, item => item.IsComplete = true);
        }

        [Fact]
        public void ReturnOnlyInCompleteItems()
        {
            var specs = new List<ISpecification<ToDoItem>>
            {
                new IsCompleteSpecification(false)
            };

            var service = new ToDoItemService(_repository);

            var items = service.GetToDoItems(specs);

            Assert.All(items, item => item.IsComplete = false);
        }

        [Fact]
        public void ReturnOnlyOverdueItems()
        {
            var dateParam = DateTime.Now;

            var specs = new List<ISpecification<ToDoItem>>
            {
                new IsOverdueSpecification(dateParam)
            };

            var service = new ToDoItemService(_repository);

            var items = service.GetToDoItems(specs);

            Assert.All(items, item =>
            {
                Assert.True(item.DueDate < dateParam);
            });
        }

        [Fact]
        public void ReturnOnlyOverdueIncompleteItems()
        {
            var dateParam = DateTime.Now;

            var specs = new List<ISpecification<ToDoItem>>
            {
                new IsOverdueSpecification(dateParam),
                new IsCompleteSpecification(false)
            };

            var service = new ToDoItemService(_repository);

            var items = service.GetToDoItems(specs);

            Assert.All(items, item =>
            {
                Assert.True(item.DueDate < dateParam);
                Assert.True(item.IsComplete == false);
            });
        }
    }
}
