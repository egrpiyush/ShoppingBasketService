using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasket.Application.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductModel>>
    {
        public class Handler : IRequestHandler<GetProductsQuery, List<ProductModel>>
        {
            public Handler()
            {
            }
            
            public async Task<List<ProductModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                return GetSampleProducts();
            }

            private List<ProductModel> GetSampleProducts()
            {
                return new List<ProductModel> 
                {
                    new ProductModel{ Id = 1, Name = "Shaving gel", Price = 20, Description = "Men's shaving gel", ImageUrl = "https://picsum.photos/200" },
                    new ProductModel{ Id = 2, Name = "Shaving cream", Price = 25, Description = "Men's shaving cream", ImageUrl = "https://picsum.photos/200" },
                    new ProductModel{ Id = 3, Name = "Gillette Mach3 Turbo", Price = 30, Description = "Men's Premium Saving blades", ImageUrl = "https://picsum.photos/200" },
                    new ProductModel{ Id = 4, Name = "Gillette Pink", Price = 35, Description = "Women's premium shaving blade", ImageUrl = "https://picsum.photos/200" },
                    new ProductModel{ Id = 5, Name = "Basketball", Price = 50, Description = "Durable quality basketball", ImageUrl = "https://picsum.photos/200" },
                    new ProductModel{ Id = 6, Name = "Hockey Stick", Price = 500, Description = "Premium quality, solid built hockey stick", ImageUrl = "https://picsum.photos/200" },
                    new ProductModel{ Id = 7, Name = "Stic assorted color pens", Price = 5, Description = "Stic's assorted color pens", ImageUrl = "https://picsum.photos/200" },
                    new ProductModel{ Id = 8, Name = "Blue Ink", Price = 5, Description = "Blue ink", ImageUrl = "https://picsum.photos/200" },
                    new ProductModel{ Id = 8, Name = "Pencil", Price = 1.5M, Description = "Pencil", ImageUrl = "https://picsum.photos/200" }
                };
            }
        }
    }
}
