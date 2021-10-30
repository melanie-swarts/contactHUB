using ContactHub.Data.Models;

namespace ContactHub.WebAPI.Functions
{
    public abstract class BaseFunction
    {
        private static Context _context;

        protected static Context Context
        {
            get
            {
                if (_context != null)
                {
                    return _context;
                }

                return _context = new Context();
            }
        }
    }
}
