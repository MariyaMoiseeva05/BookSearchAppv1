using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class CharacterRepositorySQL : IRepository<Character>
    {
        private BookSearchContext db;
        public CharacterRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Character Character)
        {
            db.Characters.Add(Character);
            db.SaveChanges();
        }
        public void Delete(object characterId)
        {
            var character = db.Characters.FirstOrDefault(x => x.CharacterId == (int)characterId);

            if (character != null)
            {
                db.Characters.Remove(character);
                db.SaveChanges();
            }
        }
        public Character GetItem(object id)
        {
            return db.Characters
                .Include(cl => cl.Book_Characters).ThenInclude(gn => gn.Book)
                .First(b => b.CharacterId == (int)id);
        }

        public IEnumerable<Character> GetAll()
        {
            return db.Characters
                .Include(cl => cl.Book_Characters).ThenInclude(gn => gn.Book)
                .ToList();
        }
        public void Update(Character Character, object characterId)
        {
            var character = db.Characters.Find((int)characterId);
            character.Name = Character.Name;
            character.Other_name = Character.Other_name;
            character.Sex = Character.Sex;
            character.View = Character.View;
            character.Biography = Character.Biography;
            character.Appearance = Character.Appearance;
            character.Date_of_Birth = Character.Date_of_Birth;
            character.Date_of_Death = Character.Date_of_Death;
            character.ImagePath = Character.ImagePath;
            character.ImageLink = Character.ImageLink;
            character.Book_Characters = Character.Book_Characters;

            db.Characters.Update(character);
            db.SaveChanges();
        }
    }
}

