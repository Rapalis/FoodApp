using AutoMapper;
using FoodApp.Models;
using FoodApp.Models.DataTransferObjects;
using FoodApp.Profiles;
using FoodApp.Repositories;
using FoodApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UTests
{
    public class ReviewsServiceTests
    {
        IReviewsService _ReviewsService;
        Mock<IReviewsRepository> moqReviewsRepository = new Mock<IReviewsRepository>();
        Mock<IDishesRepository> moqDishesRepository = new Mock<IDishesRepository>();
        IMapper mapper;

        public ReviewsServiceTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DishProfile());
                cfg.AddProfile(new ReviewProfile());
                cfg.AddProfile(new ReviewProfile());
            }
           );
            mapper = new Mapper(configuration);


            _ReviewsService = new ReviewsService(moqDishesRepository.Object, moqReviewsRepository.Object, mapper);
        }

        [Fact]
        public async void AddNewReviewWithBadDishIdTest()
        {
            // Arange
            long DishID = 1;

            moqDishesRepository.Setup(DishRep => DishRep.Exists(DishID).Result).Returns(false);

            //Act
            var result = await _ReviewsService.CreateAsync(DishID, new CreateReviewDTO());

            //Assert
            Assert.Null(result);
            moqReviewsRepository.Verify(mock => mock.CreateAsync(It.IsAny<Review>()), Times.Never());

        }

        [Fact]
        public async void AddNewReviewTest()
        {
            const string Description = "Descript";
            const long userID = 1;
            DateTime dateTime = DateTime.UtcNow;
            const short score = 1;
            long DishID = 1;

            //Arange
            CreateReviewDTO createReviewDto = new CreateReviewDTO
            {
                Date = dateTime,
                Message = Description,
                Score = score
            };

            Review fakeReview = new Review
            {
                Date = dateTime,
                Message = Description,
                Score = score,
                UserId = userID,
                User = new User(),
                DishID = DishID,
                Dish = new Dish()
            };

            moqDishesRepository.Setup(DishRep => DishRep.Exists(DishID).Result).Returns(true);
            moqReviewsRepository.Setup(ReviewRep => ReviewRep.CreateAsync(It.Is<Review>(p => p.Date == dateTime && p.Message == Description && p.Score == score)).Result).Returns(fakeReview);

            //Act
            var result = await _ReviewsService.CreateAsync(DishID, createReviewDto);

            //Assert
            Assert.NotNull(result);
            moqReviewsRepository.Verify(mock => mock.CreateAsync(It.Is<Review>(p => p.Date == dateTime && p.Message == Description && p.Score == score)), Times.Once());

        }

        [Fact]
        public async void UpdateReviewTest()
        {
            const string Description = "Descript";
            const long userID = 1;
            DateTime dateTime = DateTime.UtcNow;
            const short score = 1;
            long DishID = 1;
            long ReviewID = 1;
            //Arange
            CreateReviewDTO UpdateReviewDto = new CreateReviewDTO
            {
                Date = dateTime,
                Message = Description,
                Score = score
            };

            Review fakeReview = new Review
            {
                Date = dateTime,
                Message = Description,
                Score = score,
                UserId = userID,
                User = new User(),
                DishID = DishID,
                Dish = new Dish()
            };

            moqReviewsRepository.Setup(ReviewRep => ReviewRep.UpdateAsync(It.Is<Review>(p => p.Date == dateTime && p.Message == Description && p.Score == score)).Result).Returns(fakeReview);

            //Act
            var result = await _ReviewsService.UpdateAsync(ReviewID, UpdateReviewDto);

            //Assert
            Assert.NotNull(result);
            moqReviewsRepository.Verify(mock => mock.UpdateAsync(It.Is<Review>(p => p.Date == dateTime && p.Message == Description && p.Score == score)), Times.Once());

        }

        [Fact]
        public async void GetAsyncReviewTest()
        {
            const string Description = "Descript";
            const long userID = 1;
            DateTime dateTime = DateTime.UtcNow;
            const short score = 1;
            long DishID = 1;
            long ReviewID = 1;
            //Arange
            Review fakeReview = new Review
            {
                Date = dateTime,
                Message = Description,
                Score = score,
                UserId = userID,
                User = new User(),
                DishID = DishID,
                Dish = new Dish()
            };

            moqReviewsRepository.Setup(providerRep => providerRep.GetAsync(ReviewID).Result).Returns(fakeReview);

            //Act
            var result = await _ReviewsService.GetAsync(ReviewID);

            //Assert
            Assert.NotNull(result);
            moqReviewsRepository.Verify(mock => mock.GetAsync(ReviewID), Times.Once());
        }

        [Fact]
        public async void GetAllReviewsWithBadDishTest()
        {
            long DishID = 1;

            //Arange
            moqDishesRepository.Setup(DishRep => DishRep.Exists(DishID).Result).Returns(false);

            //Act
            var result = await _ReviewsService.GetAllAsync(DishID);

            //Assert
            Assert.Null(result);
            moqReviewsRepository.Verify(mock => mock.GetAllAsync(It.IsAny<long>()), Times.Never());
        }

        [Fact]
        public async void GetAllAsyncReviewTest()
        {
            const string Description = "Descript";
            const long userID = 1;
            DateTime dateTime = DateTime.UtcNow;
            const short score = 1;

            const string Description1 = "Descript for second review";
            const long userID1 = 2;
            DateTime dateTime1 = DateTime.UtcNow;
            const short score1 = 2;

            long DishID = 1;

            //Arange
            Review fakeReview = new Review
            {
                Date = dateTime,
                Message = Description,
                Score = score,
                UserId = userID,
                User = new User(),
                DishID = DishID,
                Dish = new Dish()
            };

            Review fakeReview1 = new Review
            {
                Date = dateTime1,
                Message = Description1,
                Score = score1,
                UserId = userID1,
                User = new User(),
                DishID = DishID,
                Dish = new Dish()
            };

            Review[] reviews = new Review[2];
            reviews[0] = fakeReview;
            reviews[1] = fakeReview1;

            moqDishesRepository.Setup(DishRep => DishRep.Exists(DishID).Result).Returns(true);
            moqReviewsRepository.Setup(providerRep => providerRep.GetAllAsync(DishID).Result).Returns(reviews);

            //Act
            var result = await _ReviewsService.GetAllAsync(DishID);

            //Assert
            Assert.NotNull(result);
            moqReviewsRepository.Verify(mock => mock.GetAllAsync(DishID), Times.Once());
        }
        [Fact]
        public async void DeleteReviewTest()
        {
            const long Id = 1;
            //Arange

            moqReviewsRepository.Setup(providerRep => providerRep.DeleteAsync(Id).Result).Returns(true);

            //Act
            var result = await _ReviewsService.DeleteAsync(Id);

            //Assert
            Assert.True(result);

        }

        [Theory]
        [InlineData(1.5d, 1, 2)]
        [InlineData(5, 5, 5, 5, 5)]
        [InlineData(3, 1, 2, 6)]
        [InlineData(2, 2)]

        public async void CaculateAvarageDishScoreTest(double expectedAvarage, params int[] scores)
        {
            //Arange
            const long dishId = 1;
            IEnumerable<Review> moqReviews = new List<Review>(scores.Select(s => new Review { Score = (short)s }));
            // double avarage = scores.Aggregate(0, (total, value) => total + value) / scores.Length;
            moqReviewsRepository.Setup(rep => rep.GetAllAsync(dishId).Result).Returns(moqReviews);

            //Act
            double result = await _ReviewsService.CaculateAvarageDishScore(dishId);
            //Assert
            Assert.Equal(expectedAvarage, result);
        }
    }
}
