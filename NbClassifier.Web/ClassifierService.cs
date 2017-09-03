using NbClassifier.Model;
using NbClassifier.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbClassifier.Web
{
    public static class ClassifierService
    {
        private static INaiveBayesClassifier classifier = 
            new MultinomialClassifier(2);

        public static bool IsInitialized { get; private set; } = false;

        public static void Initialize(AppDbContext context)
        {
            var query =
                from r in context.Reviews
                join rc in context.ReviewCategory
                    on r.ReviewId equals rc.ReviewId
                join c in context.Categories on rc.CategoryId equals c.CategoryId
                select new { r.Text, Category = c.Name };

            var positiveReviews = (
                from review in query
                where review.Category == "Positive"
                select review.Text).ToList();

            var negativeReviews = (
                from review in query
                where review.Category == "Negative"
                select review.Text).ToList();

            foreach (var review in positiveReviews)
            {
                classifier.Train(review, 0);
            }

            foreach (var review in negativeReviews)
            {
                classifier.Train(review, 1);
            }

            IsInitialized = true;
        }

        public static string Classify(string review)
        {
            return classifier.DetermineCategory(review) == 0 
                ? "Positive"
                : "Negative";
        }
    }
}
