using System;
using System.Collections.Generic;
using System.Linq;

namespace NbClassifier.Model
{
    public class BernoulliClassifier : INaiveBayesClassifier
    {
        private Dictionary<string, int[]> vocabulary;
        private int[] docsCountCategory;

        public BernoulliClassifier(int nCategories)
        {
            if (nCategories < 2)
                throw new ArgumentException("MIN number of categories = 2");
            vocabulary = new Dictionary<string, int[]>();
            docsCountCategory = new int[nCategories];
        }

        public int DetermineCategory(string document)
        {
            var words = new HashSet<string>(
                DocumentHelper.ExtractWordsFromDocument(document));

            double[] categoriesProbabilities = new double[docsCountCategory.Length];
            int nDocsTotal = docsCountCategory.Sum();
            for (int i = 0; i < categoriesProbabilities.Length; ++i)
            {
                categoriesProbabilities[i] = docsCountCategory[i] / (double)nDocsTotal;
            }

            double[] posteriorProbabilities = new double[docsCountCategory.Length];
            for (int i = 0; i < docsCountCategory.Length; ++i)
            {
                posteriorProbabilities[i] = categoriesProbabilities[i];
            }

            foreach (var item in vocabulary)
            {
                bool b = words.Contains(item.Key);
                double[] wordProbabilities = new double[docsCountCategory.Length];
                for (int i = 0; i < wordProbabilities.Length; ++i)
                {
                    wordProbabilities[i] = (item.Value[i] + 1)
                        / (double)(docsCountCategory[i] + vocabulary.Count);
                }

                if (b)
                {
                    for (int i = 0; i < posteriorProbabilities.Length; ++i)
                    {
                        posteriorProbabilities[i] *= wordProbabilities[i];
                    }
                }
                else
                {
                    for (int i = 0; i < posteriorProbabilities.Length; ++i)
                    {
                        posteriorProbabilities[i] *= 1 - wordProbabilities[i];
                    }
                }
            }

            return posteriorProbabilities.MaxElementIndex();
        }

        public void Train(string document, int category)
        {
            ++docsCountCategory[category];
            var words = new HashSet<string>(
                DocumentHelper.ExtractWordsFromDocument(document));
            foreach (var word in words)
            {
                if (!vocabulary.ContainsKey(word))
                {
                    vocabulary.Add(word, new int[docsCountCategory.Length]);
                }
                ++(vocabulary[word][category]);
            }
        }
        
    }
}