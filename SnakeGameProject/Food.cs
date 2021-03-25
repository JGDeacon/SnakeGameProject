using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SnakeGameProject
{
    public enum FoodName { Bacon, CottonCandy, Person, Apple }
    public class Food
    {
        public FoodName FoodType { get; set; }
        public int PointValue
        {
            get
            {
                return GetPointValue(FoodType);
            }
        }
        public char FoodCharacter
        {
            get
            {
                return GetFoodCharacter(FoodType);
            }
        }
        public int GetPointValue(FoodName foodName)
        {
            int pointValueOfFood;
            switch (foodName)
            {
                case FoodName.Apple:
                    pointValueOfFood = 10;
                    return pointValueOfFood;
                case FoodName.CottonCandy:
                    pointValueOfFood = 15;
                    return pointValueOfFood;
                case FoodName.Person:
                    pointValueOfFood = 25;
                    return pointValueOfFood;
                case FoodName.Bacon:
                    pointValueOfFood = 50;
                    return pointValueOfFood;
                default:
                    pointValueOfFood = 10;
                    return pointValueOfFood;
            }
        }
        public char GetFoodCharacter(FoodName foodName)
        {
            char characterValueOfFood;
            switch (foodName)
            {
                case FoodName.Apple:
                    characterValueOfFood = '@';
                    return characterValueOfFood;
                case FoodName.CottonCandy:
                    characterValueOfFood = '*';
                    return characterValueOfFood;
                case FoodName.Person:
                    characterValueOfFood = '¥';
                    return characterValueOfFood;
                case FoodName.Bacon:
                    characterValueOfFood = '~';
                    return characterValueOfFood;
                default:
                    characterValueOfFood = '@';
                    return characterValueOfFood;
            }
        }
        public Food()
        {
        }
        public Food(FoodName foodName)
        {
            FoodType = foodName;
        }
    }
}

















