using Microsoft.AspNetCore.Mvc;
using SportsWebsite.Models;

namespace SportsWebsite.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index(string? category = null)
        {
            var allNews = GetAllNews();
            var categories = allNews.Select(n => n.Category).Distinct().ToList();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                allNews = allNews.Where(n => n.Category == category).ToList();
            }

            ViewBag.AllNews = allNews;
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = category ?? "All";

            return View();
        }

        public IActionResult Details(int id)
        {
            var article = GetAllNews().FirstOrDefault(n => n.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        public IActionResult NewsModal(string category = "All")
        {
            var allNews = GetAllNews();

            if (category != "All")
            {
                allNews = allNews.Where(n => n.Category == category).ToList();
            }

            return PartialView(allNews);
        }

        [HttpPost]
        public IActionResult IncrementViewCount([FromBody] ViewCountRequest request)
        {
            var newViewCount = request.CurrentCount + 1;
            return Json(new { success = true, viewCount = newViewCount });
        }

        private List<NewsItem> GetAllNews()
        {
            return new List<NewsItem>
            {
                new NewsItem
                {
                    Id = 1,
                    Title = "Women's National Team Prepares for Nations League Final Matches",
                    Excerpt = "The women's national team has begun preparations for the final matches of the Nations League.",
                    Content = "The women's national team has begun intensive preparations for the upcoming Nations League final matches. Coach Sarah Williams has implemented new tactical approaches and the team is showing excellent form in training sessions. The players are confident and ready to face the challenges ahead.",
                    Author = "Sports Reporter",
                    Category = "Women's Team",
                    PublishedDate = DateTime.Now.AddDays(-1),
                    ViewCount = 1250,
                    ImageUrl = "/images/womens-team.jpg"
                },
                new NewsItem
                {
                    Id = 2,
                    Title = "Men's Team Championship Victory",
                    Excerpt = "Historic victory in the championship final brings glory to the team.",
                    Content = "In a thrilling championship final, our men's team delivered an outstanding performance to secure a historic victory. The match was decided in the final minutes with a spectacular goal that will be remembered for years to come.",
                    Author = "Match Reporter",
                    Category = "Men's Team",
                    PublishedDate = DateTime.Now.AddDays(-3),
                    ViewCount = 890,
                    ImageUrl = "/images/mens-victory.jpg"
                },
                new NewsItem
                {
                    Id = 3,
                    Title = "Youth Academy Success Stories",
                    Excerpt = "Young talents showcase exceptional skills in recent tournaments.",
                    Content = "Our youth academy continues to produce exceptional talent. Recent tournaments have highlighted the skills and dedication of our young players, with several receiving recognition from national selectors.",
                    Author = "Youth Coach",
                    Category = "Youth Team",
                    PublishedDate = DateTime.Now.AddDays(-5),
                    ViewCount = 567,
                    ImageUrl = "/images/youth-success.jpg"
                },
                new NewsItem
                {
                    Id = 4,
                    Title = "New Training Facility Opens",
                    Excerpt = "State-of-the-art facility enhances team preparation capabilities.",
                    Content = "The new training facility features cutting-edge equipment and technology to help our teams prepare for competitions. The facility includes modern gym equipment, recovery rooms, and tactical analysis centers.",
                    Author = "Facility Manager",
                    Category = "General",
                    PublishedDate = DateTime.Now.AddDays(-7),
                    ViewCount = 1100,
                    ImageUrl = "/images/new-facility.jpg"
                },
                new NewsItem
                {
                    Id = 5,
                    Title = "ჭაბუკთა 'ა' ლიგა | 'ლელომ' ტიტული უმძიმეს ბრძოლაში დაიცვა",
                    Excerpt = "ბოლო 10 წლის მანძილზე უფროსი ასაკის ჭაბუკ მორაგბეთა პირველობის ტიტულის მფლობელს 'აია'-'ლელოს' რიგით მე-8 დაპირისპირება არკვევდა.",
                    Content = "ბოლო 10 წლის მანძილზე უფროსი ასაკის ჭაბუკ მორაგბეთა პირველობის ტიტულის მფლობელს 'აია'-'ლელოს' რიგით მე-8 დაპირისპირება (მათ შორის ფინალში მეოთხედ) არკვევდა. აღნიშნულ პერიოდში დიდ დიღმელები 6-ჯერ გახდნენ ჩემპიონები (ერთხელ ფინალში 'ხვამლს' მოუგეს), 'აიამ' კი ტიტულის მოპოვება 2-ჯერ მოახერხა.\n\nუკვე მრავალი წელია, რაც 'ლელო' საქართველოს ახალგაზრდული და ეროვნული ნაკრების მთავარ დონორს წარმოადგენს. ქართული რაგბის ბერმუხა ბათუ (ვასილ) კევლიშვილის დიდი ძალისხმევითა და თაოსნობით, 'ლელოს' რაგბის აკადემიაში მიმდინარე გამართულმა, საათივით აწყობილმა, უამრავი ინოვაციით გაჯერებულმა საწვრთნელო პროცესმა დიდ დიღმელებს ჭაბუკ მორაგბეთა ორივე ასაკის პირველობებზე პრაქტიკულად ჰეგემონია დაამყარებინა.",
                    Author = "სპორტული რეპორტიორი",
                    Category = "Youth Team",
                    PublishedDate = DateTime.Now.AddDays(-2),
                    ViewCount = 1850,
                    ImageUrl = "https://hebbkx1anhila5yf.public.blob.vercel-storage.com/4bebcd1a-e285-44dd-9d18-e67be8b94575.jpg-lPuPFwmePbLuJFxxjut63NadgkFNnw.jpeg"
                },
                new NewsItem
                {
                    Id = 6,
                    Title = "ლელო ჭაბუკთა \"ა\" ლიგის 7 კაცა ტურნირის გამარჯვებულია",
                    Excerpt = "12 აპრილს ლოკომოტივის ბაზაზე გაიმართა ჭაბუკთა \"ა\" ლიგის 7 კაცა ტურნირი სადაც გამარჯვებული, საქართველოს ჩემპიონი ხორბალაძე-შანიძის გუნდმა გახდა.",
                    Content = "12 აპრილს ლოკომოტივის ბაზაზე გაიმართა ჭაბუკთა \"ა\" ლიგის 7 კაცა ტურნირი სადაც გამარჯვებული, საქართველოს ჩემპიონი ხორბალაძე-შანიძის გუნდმა გახდა.",
                    Author = "ტურნირის ორგანიზატორები",
                    Category = "Youth Team",
                    PublishedDate = DateTime.Now.AddDays(-4),
                    ViewCount = 920,
                    ImageUrl = "https://hebbkx1anhila5yf.public.blob.vercel-storage.com/1fd63848-f6b3-4c77-9efa-9cff3663dc6c.jpg-CqcaMUcbbEF3vXtVeUoF0xFPDleh0O.jpeg"
                },
                new NewsItem
                {
                    Id = 7,
                    Title = "ლელო ესპუართა ლიგის ჩემპიონია",
                    Excerpt = "3 მაისს, ავჭალის სარაგბო სტადიონზე ესპუართა ლიგის ფინალური შეხვედრა \"ბათუმთან\" გვქონდა სადაც მეტოქე ანგარიშით 38:20 დავამარცხეთ.",
                    Content = "3 მაისს, ავჭალის სარაგბო სტადიონზე ესპუართა ლიგის ფინალური შეხვედრა \"ბათუმთან\" გვქონდა სადაც მეტოქე ანგარიშით 38:20 დავამარცხეთ და ესპუართა ლიგის ჩემპიონობა მინიმუმ ერთი წლით გავიხანგრძლივეთ.\n\nესპუართა ლიგის ფინალში უფროსებთან ერთად მონაწილეობა მიიღეს ახალგაზრდა მორაგბეებმაც რომლებიც მომავალი წლიდან კაცთა ლიგაში იასპარეზებენ.",
                    Author = "კლუბის ადმინისტრაცია",
                    Category = "General",
                    PublishedDate = DateTime.Now.AddDays(-6),
                    ViewCount = 1340,
                    ImageUrl = "https://hebbkx1anhila5yf.public.blob.vercel-storage.com/a7818084-195b-47f1-b81d-988d070f9d7d.jpg-2XJwiAEI3Ai6oRta4QmmPa1LY1SYjU.jpeg"
                },
                new NewsItem
                {
                    Id = 8,
                    Title = "Season Ticket Sales Break Records",
                    Excerpt = "Unprecedented fan support shown through record ticket sales.",
                    Content = "Season ticket sales have reached unprecedented levels, showing the incredible support from our fans. The loyalty and enthusiasm of our supporters continues to inspire the teams to achieve greater heights.",
                    Author = "Marketing Team",
                    Category = "General",
                    PublishedDate = DateTime.Now.AddDays(-9),
                    ViewCount = 780,
                    ImageUrl = "/images/ticket-sales.jpg"
                }
            };
        }
    }
}