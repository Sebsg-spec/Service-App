using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service_App.Data;
using Service_App.Models;

namespace Service_App.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public IndexModel(Service_App.Data.Service_AppContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Members != null)
            {
                Member = await _context.Members.ToListAsync();
            }
        }
    }
}
