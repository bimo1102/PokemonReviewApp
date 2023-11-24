﻿namespace PokemonReviewApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Gym { get; set; }
        public Country Country { get; set; }
        public ICollection<PokemonOwner> PokemonOwner { get; set; }
    }
}
