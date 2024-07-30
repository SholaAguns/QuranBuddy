using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace QuranBuddyAPI_Tests.Models
{
    internal class Mocks
    {
    }

    public class FakeContext : QuranDBContext
    {
        public FakeContext(DbContextOptions<QuranDBContext> options) : base(options) { }

    }
}
