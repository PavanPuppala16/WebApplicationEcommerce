using Microsoft.AspNetCore.Mvc;
using WebApplicationEcommerce.Models;

namespace WebApplicationEcommerce.Controllers
{
    public class UplaodProductController : Controller
    {
        private readonly DataBasedbContext _context;
        public UplaodProductController(DataBasedbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromForm] Products PRODUCT)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(PRODUCT);
            //create a new Product instance.
            Products newproduct = new()
            {
                Description = PRODUCT.Description,
                Price = PRODUCT.Price,
                Size = PRODUCT.Size,
                ManufactoringDate = PRODUCT.ManufactoringDate
            };
            //create a Photo list to store the upload files.
            List<Photo> photolist = new List<Photo>();
            if (PRODUCT.Files.Count > 0)
            {
                foreach (var formFile in PRODUCT.Files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await formFile.CopyToAsync(memoryStream);
                            // Upload the file if less than 2 MB
                            if (memoryStream.Length < 2097152)
                            {
                                //based on the upload file to create Photo instance.
                                //You can also check the database, whether the image exists in the database.
                                var newphoto = new Photo()
                                {
                                    Bytes = memoryStream.ToArray(),
                                    Description = formFile.FileName,
                                    FileExtension = Path.GetExtension(formFile.FileName),
                                    Size = formFile.Length,
                                };
                                //add the photo instance to the list.
                                photolist.Add(newphoto);
                            }
                            else
                            {
                                ModelState.AddModelError("File", "The file is too large.");
                            }
                        }
                    }
                }
            }
            //assign the photos to the Product, using the navigation property.
            newproduct.Photos = photolist;
            _context.PRODUCT.Add(newproduct);
            _context.SaveChanges();

            return View();
        }
    }
}
