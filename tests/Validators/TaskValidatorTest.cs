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

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });

            Assert.Equal("Title cannot be empty or whitespace.", ex.Message);
        }

        [Fact]
        public void ValidatorTitle_WhenIsWhiteSpace_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("", "This a test example", TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });

            Assert.Equal("Title cannot be empty or whitespace.", ex.Message);

        }

        [Fact]
        public void ValidatorTitle_WhenTitleIsTooShort_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var shortTitle = new string('A', 5);

            var task = new TaskDTO(shortTitle, "This a test example", TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });

            Assert.Equal("Title must be between 6 and 50 characters long.", ex.Message);

        }

        [Fact]
        public void ValidatorTitle_WhenTitleExactly6Characters_DoesNotThrowException()
        {
            var userId = Guid.NewGuid();
            var shortTitle = new string('A', 6);

            var task = new TaskDTO(shortTitle, "This a test example", TagTypeModel.Others, userId);

            var exception = Record.Exception(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });

            Assert.Null(exception);
        }


        [Fact]
        public void ValidatorTitle_WhenTitleIsTooLong_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var longTitle = new string('A', 51);

            var task = new TaskDTO(longTitle, "This a test example", TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });

            Assert.Equal("Title must be between 6 and 50 characters long.", ex.Message);
        }


        [Fact]
        public void ValidatorTitle_WhenTitleExactly50Characters_DoesNotThrowException()
        {
            var userId = Guid.NewGuid();
            var longTitle = new string('A', 50);

            var task = new TaskDTO(longTitle, "This a test example", TagTypeModel.Others, userId);

            var exception = Record.Exception(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });

            Assert.Null(exception);
        }

        [Fact]
        public void ValidatorTitle_WithSpecialCharacters_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("Title!@#", "Valid description", TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });

            Assert.Equal("Title can only contain letters, numbers and spaces.", ex.Message);
        }

        [Fact]
        public void ValidatorTitle_WithMultipleConsecutiveSpaces_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("Valid  Title", "Valid description", TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorTitle(task.Title);
            });

            Assert.Equal("Title cannot contain multiple consecutive spaces.", ex.Message);
        }

        [Fact]
        public void ValidatorDescription_EmptyDescription_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("Study", null, TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });

            Assert.Equal("Description cannot be empty or whitespace.", ex.Message);
        }

        [Fact]
        public void ValidatorDescription_WhenIsWhiteSpace_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("Study", "", TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });

            Assert.Equal("Description cannot be empty or whitespace.", ex.Message);
        }

        public void ValidatorDescription_WhenDescriptionIsTooShort_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var task = new TaskDTO("Study", "This", TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });

            Assert.Equal("Description must be between 10 and 250 characters long.", ex.Message);
        }

        [Fact]
        public void ValidatorDescription_WhenDescriptionExactly10Characters_DoesNotThrowException()
        {
            var userId = Guid.NewGuid();
            var shortDescription = new string('A', 10);

            var task = new TaskDTO("Study", shortDescription, TagTypeModel.Others, userId);

            var exception = Record.Exception(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });

            Assert.Null(exception);
        }

        [Fact]
        public void ValidatorDescription_WhenDescriptionIsTooLong_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var longDescription = new string('A', 300);

            var task = new TaskDTO("Study", longDescription, TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });

            Assert.Equal("Description must be between 10 and 250 characters long.", ex.Message);
        }

        [Fact]
        public void ValidatorDescription_WhenDescriptionExactly250Characters_DoesNotThrowException()
        {
            var userId = Guid.NewGuid();
            var shortDescription = new string('A', 250);

            var task = new TaskDTO("Study", shortDescription, TagTypeModel.Others, userId);

            var exception = Record.Exception(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });

            Assert.Null(exception);
        }

        [Fact]
        public void ValidatorDescription_WithInvalidCharacters_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var description = "This description contains invalid symbol: #";
            var task = new TaskDTO("Valid Title", description, TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });

            Assert.Equal("Description contains invalid characters.", ex.Message);
        }

        [Fact]
        public void ValidatorDescription_WithRepetitiveCharacters_ThrowsException()
        {
            var userId = Guid.NewGuid();
            var repetitive = "AAAAABBBBBBBBBBB";
            var task = new TaskDTO("Valid Title", repetitive, TagTypeModel.Others, userId);

            var ex = Assert.Throws<DomainValidationException>(() =>
            {
                _provider.ValidatorDescription(task.Description);
            });

            Assert.Equal("Description contains repetitive characters.", ex.Message);
        }
    }
}