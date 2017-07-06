using System;
using System.Collections.Generic;
using System.Linq;

namespace NbClassifier.Model
{
    public class MultinomialClassifier : INaiveBayesClassifier
    {
        private Dictionary<string, int[]> vocabulary;
        private int[] docsCountCategory;

        public MultinomialClassifier(int nCategories)
        {
            if (nCategories < 2)
                throw new ArgumentException("MIN number of categories = 2!");
            vocabulary = new Dictionary<string, int[]>();
            docsCountCategory = new int[nCategories];
        }

        public int DetermineCategory(string document)
        {
            var words = DocumentHelper.ExtractWordsFromDocument(document);

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

            int[] categoriesOccurrences = new int[docsCountCategory.Length];
            for (int i = 0; i < categoriesOccurrences.Length; ++i)
            {
                categoriesOccurrences[i] = vocabulary.Sum(keyVal => keyVal.Value[i]);
            }

            foreach (var word in words)
            {
                if (vocabulary.ContainsKey(word))
                {
                    double[] wordProbabilities = new double[docsCountCategory.Length];
                    for (int i = 0; i < wordProbabilities.Length; ++i)
                    {
                        wordProbabilities[i] = (vocabulary[word][i] + 1)
                            / (double)(categoriesOccurrences[i] + vocabulary.Count);
                        posteriorProbabilities[i] *= wordProbabilities[i];
                    }
                }
            }

            return posteriorProbabilities.MaxElementIndex();
        }

        public void Train(string document, int category)
        {
            ++docsCountCategory[category];
            var words = DocumentHelper.ExtractWordsFromDocument(document);
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