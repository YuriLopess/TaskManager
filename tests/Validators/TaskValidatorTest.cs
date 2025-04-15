using System;
using Microsoft.AspNetCore.Identity;
using src.Dto;
using src.Exceptions;
using src.Models;
using src.Validators.Task;


namespace tests.Validators
{
    public class TaskValidatorTest
    {
        private readonly ITaskValidator _provider;

        public TaskValidatorTest()
        {
            _provider = new TaskValidator();
        }

        [Fact]
        public void ValidatorTitle_EmptyTitle_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO(null, "This a test example", TagTypeModel.Others, userId);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });
        }

        [Fact]
        public void ValidatorTitle_WhenIsWhiteSpace_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("", "This a test example", TagTypeModel.Others, userId);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });
        }

        public void ValidatorTitle_WhenTitleIsTooShort_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("Study", "This a test example", TagTypeModel.Others, userId);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });
        }

        [Fact]
        public void ValidatorTitle_WhenTitleIsTooLong_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var longTitle = new string('A', 51);

            var task = new TaskDTO(longTitle, "This a test example", TagTypeModel.Others, userId);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });
        }

        [Fact]
        public void ValidatorDescription_EmptyDescription_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("Study", null, TagTypeModel.Others, userId);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });
        }

        [Fact]
        public void ValidatorDescription_WhenIsWhiteSpace_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("Study", "", TagTypeModel.Others, userId);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });
        }

        public void ValidatorDescription_WhenDescriptionIsTooShort_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("Study", "This", TagTypeModel.Others, userId);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });
        }

        [Fact]
        public void ValidatorDescription_WhenDescriptionIsTooLong_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var longDescription = new string('A', 300);

            var task = new TaskDTO("Study", longDescription, TagTypeModel.Others, userId);

            Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });
        }
    }
}
