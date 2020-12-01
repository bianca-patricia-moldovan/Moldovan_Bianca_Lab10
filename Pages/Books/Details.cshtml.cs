﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moldovan_Bianca_Lab8.Data;
using Moldovan_Bianca_Lab8.Models;

namespace Moldovan_Bianca_Lab8.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Moldovan_Bianca_Lab8.Data.Moldovan_Bianca_Lab8Context _context;

        public DetailsModel(Moldovan_Bianca_Lab8.Data.Moldovan_Bianca_Lab8Context context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.Include(b => b.Publisher).FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
