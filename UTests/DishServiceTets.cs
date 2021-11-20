using System;
using AutoMapper;
using Moq;
using Xunit;
using FoodApp.Services;
using FoodApp.Repositories;
using FoodApp.DataAccess;
using FoodApp.Profiles;
using FoodApp.Models;

namespace UTests
{
    public class DishesServiceUnitTest
    {
        IDishesService _dishesService;
        Mock<IProvidersRepository> moqProvidersRepository = new Mock<IProvidersRepository>();
        Mock<IDishesRepository> moqDishesRepository = new Mock<IDishesRepository>();
        IMapper mapper;

        public DishesServiceUnitTest()
        {
            var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new DishProfile());
                    cfg.AddProfile(new ProviderProfile());
                    cfg.AddProfile(new ReviewProfile());
                }
            );
            mapper = new Mapper(configuration);


            _dishesService = new DishesService(moqProvidersRepository.Object, moqDishesRepository.Object, mapper);
        }

        [Fact]
        public async void AddNewDishTest()
        {
            //Arange
            long providerId = 1;
            moqProvidersRepository.Setup(providerRep => providerRep.Exists(providerId).Result).Returns(true);
            var moqCreate = moqDishesRepository.Setup(dishesRep => dishesRep.CreateAsync(It.IsAny<Dish>()).Result).Returns(new Dish());

            //Act
            var result = await _dishesService.CreateAsync(providerId, new CreateDishDTO());

            //Assert
            Assert.NotNull(result);
            moqDishesRepository.Verify(mock => mock.CreateAsync(It.IsAny<Dish>()), Times.Once());

        }
    }
}
