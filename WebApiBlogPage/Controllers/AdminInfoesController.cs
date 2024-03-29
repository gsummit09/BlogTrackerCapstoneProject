﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiBlogPage.Models;

namespace WebApiBlogPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminInfoesController : ControllerBase
    {
        private readonly BlogContext _context;

        public AdminInfoesController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/AdminInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminInfo>>> GetAdminInfos()
        {
          if (_context.AdminInfos == null)
          {
              return NotFound();
          }
            return await _context.AdminInfos.ToListAsync();
        }

        // GET: api/AdminInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminInfo>> GetAdminInfo(int id)
        {
          if (_context.AdminInfos == null)
          {
              return NotFound();
          }
            var adminInfo = await _context.AdminInfos.FindAsync(id);

            if (adminInfo == null)
            {
                return NotFound();
            }

            return adminInfo;
        }

        // PUT: api/AdminInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminInfo(int id, AdminInfo adminInfo)
        {
            if (id != adminInfo.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(adminInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdminInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminInfo>> PostAdminInfo(AdminInfo adminInfo)
        {
          if (_context.AdminInfos == null)
          {
              return Problem("Entity set 'BlogContext.AdminInfos'  is null.");
          }
            _context.AdminInfos.Add(adminInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminInfo", new { id = adminInfo.AdminId }, adminInfo);
        }

        // DELETE: api/AdminInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminInfo(int id)
        {
            if (_context.AdminInfos == null)
            {
                return NotFound();
            }
            var adminInfo = await _context.AdminInfos.FindAsync(id);
            if (adminInfo == null)
            {
                return NotFound();
            }

            _context.AdminInfos.Remove(adminInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminInfoExists(int id)
        {
            return (_context.AdminInfos?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
