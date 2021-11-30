using System;
using AutoMapper;
using Moq;
using Xunit;
using FoodApp.Services;
using FoodApp.Repositories;
using FoodApp.DataAccess;
using FoodApp.Profiles;
using FoodApp.Models;
using System.Collections.Generic;

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
        public async void GetAllWithBadProviderTest()
        {
            //Arange
            const long providerId = 1;

            moqProvidersRepository.Setup(providerRep => providerRep.Exists(providerId).Result).Returns(false);

            //Act
            var result = await _dishesService.GetAllAsync(providerId);

            //Assert
            Assert.Null(result);

            moqDishesRepository.Verify(dishesRep => dishesRep.GetAllAsync(providerId), Times.Never());
        }
        

        [Fact]
        public async void UpdateDishTest()
        {
            //Arange
            const string fakeName = "Test name";
            const decimal fakePrice = 9.99M;
            const string fakeDescription = "Test description";
            const long moqdishId = 1;

            CreateDishDTO moqCreateDishDto = new CreateDishDTO
            {
                Name = fakeName,
                Price = fakePrice,
                Description = fakeDescription
            };
            Dish moqDish = new Dish
            {
                Id = moqdishId,
                Name = fakeName,
                Price = fakePrice,
                Description = fakeDescription
            };
            var moqCreate = moqDishesRepository.Setup(dishesRep => dishesRep.UpdateAsync(It.Is<Dish>(d =>
                d.Id == moqdishId && d.Name == fakeName && d.Price == fakePrice && d.Description == fakeDescription)).Result);
            moqCreate.Returns(moqDish);


            //Act
            var result = await _dishesService.UpdateAsync(moqdishId, moqCreateDishDto);

            //Assert
            VerifyDishDto(moqDish, result);
            moqDishesRepository.Verify(dishesRep => dishesRep.UpdateAsync(It.Is<Dish>(d =>
                d.Id == moqdishId && d.Name == fakeName && d.Price == fakePrice && d.Description == fakeDescription)), Times.Once());
        }


        [Fact]
        public async void GetAllTest()
        {
            //Arange
            const string fakeName = "Test name";
            const decimal fakePrice = 9.99M;
            const string fakeDescription = "Test description";
            const long providerId = 1;
            const long createdDishId = 1;

            CreateDishDTO moqCreateDishDto = new CreateDishDTO
            {
                Name = fakeName,
                Price = fakePrice,
                Description = fakeDescription
            };
            List<Dish> moqDishes = new List<Dish>
            {
                new Dish
                {
                    Id = createdDishId,
                    ProviderId = providerId,
                    Name = fakeName,
                    Price = fakePrice,
                    Description = fakeDescription
                }
            };
            moqProvidersRepository.Setup(providerRep => providerRep.Exists(providerId).Result).Returns(true);
            var moqCreate = moqDishesRepository.Setup(dishesRep => dishesRep.GetAllAsync(providerId).Result).Returns(moqDishes);


            //Act
            var result = await _dishesService.GetAllAsync(providerId);

            //Assert
            Assert.NotNull(result);
            int count = 0;
            foreach (DishDTO res in result)
            {
                VerifyDishDto(moqDishes[count], res);
                count++;
            }
            moqDishesRepository.Verify(dishesRep => dishesRep.GetAllAsync(providerId), Times.Once());

        }

        [Fact]
        public async void GetDishTest()
        {
            //Arange
            const string fakeName = "Test name";
            const decimal fakePrice = 9.99M;
            const string fakeDescription = "Test description";
            const long providerId = 1;
            const long fakeDishId = 1;

            Dish moqDish = new Dish
            {
                Id = fakeDishId,
                ProviderId = providerId,
                Name = fakeName,
                Price = fakePrice,
                Description = fakeDescription
            };

            moqDishesRepository.Setup(rep => rep.GetAsync(fakeDishId).Result).Returns(moqDish);

            //Act
            var result = await _dishesService.GetAsync(fakeDishId);

            //Assert
            VerifyDishDto(moqDish, result);
            moqDishesRepository.Verify(rep => rep.GetAsync(fakeDishId), Times.Once());
        }

        [Fact]
        public async void DeleteDishTest()
        {
            //Arange
            const long fakeDishId = 1;
            moqDishesRepository.Setup(rep => rep.DeleteAsync(fakeDishId).Result).Returns(true);

            //Act
            var result = await _dishesService.DeleteAsync(fakeDishId);

            //Assert
            Assert.True(result);
            moqDishesRepository.Verify(rep => rep.DeleteAsync(fakeDishId), Times.Once());

        }

        [Fact]
        public async void AddNewDishWithBadProviderTest()
        {
            //Arange
            const long providerId = 1;
            moqProvidersRepository.Setup(providerRep => providerRep.Exists(providerId).Result).Returns(false);

            //Act
            var result = await _dishesService.CreateAsync(providerId, new CreateDishDTO());

            //Assert
            Assert.Null(result);
            moqDishesRepository.Verify(dishesRep => dishesRep.CreateAsync(It.IsAny<Dish>()), Times.Never());
        }

        [Fact]
        public async void AddNewDishTest()
        {
            //Arange
            const string fakeName = "Test name";
            const decimal fakePrice = 9.99M;
            const string fakeDescription = "Test description";
            const long providerId = 1;
            const long createdDishId = 1;

            CreateDishDTO moqCreateDishDto = new CreateDishDTO
            {
                Name = fakeName,
                Price = fakePrice,
                Description = fakeDescription
            };
            Dish moqDish = new Dish
            {
                Id = createdDishId,
                ProviderId = providerId,
                Name = fakeName,
                Price = fakePrice,
                Description = fakeDescription
            };
            moqProvidersRepository.Setup(providerRep => providerRep.Exists(providerId).Result).Returns(true);
            var moqCreate = moqDishesRepository.Setup(dishesRep => dishesRep.CreateAsync(It.Is<Dish>(d =>
                d.ProviderId == providerId && d.Name == fakeName && d.Price == fakePrice && d.Description == fakeDescription)).Result);
            moqCreate.Returns(moqDish);
           

            //Act
            var result = await _dishesService.CreateAsync(providerId, moqCreateDishDto);

            //Assert
            VerifyDishDto(moqDish, result);
            moqDishesRepository.Verify(dishesRep => dishesRep.CreateAsync(It.Is<Dish>(d =>
                d.ProviderId == providerId && d.Name == fakeName && d.Price == fakePrice && d.Description == fakeDescription)), Times.Once());
        }

        private void VerifyDishDto(Dish dish, DishDTO dishDto)
        {
            Assert.NotNull(dish);
            Assert.Equal(dish.Id, dishDto.Id);
            Assert.Equal(dish.Name, dishDto.Name);
            Assert.Equal(dish.Price, dishDto.Price);
            Assert.Equal(dish.Description, dishDto.Description);
        }
    }
}
