using AutoMapper;
using Moq;
using Product.Server.DTOs;
using Product.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Server.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product.Server.Models.Product, ProductDto>().ReverseMap();
            });

            _mapper = config.CreateMapper();
            _service = new ProductService(_mockRepo.Object, _mapper);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product.Server.Models.Product>
            {
                new Product.Server.Models.Product { ProductID = 1, Name = "Test", Price = 10 },
                new Product.Server.Models.Product { ProductID = 2, Name = "Test2", Price = 20 }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.Equal(2, ((List<ProductDto>)result).Count);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsProduct_WhenFound()
        {
            var product = new Product.Server.Models.Product { ProductID = 1, Name = "Test", Price = 10 };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Test", result!.Name);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenNotFound()
        {
            _mockRepo.Setup(repo => repo.GetByIdAsync(99)).ReturnsAsync((Product.Server.Models.Product?)null);

            var result = await _service.GetByIdAsync(99);

            Assert.Null(result);
        }
    }
}

