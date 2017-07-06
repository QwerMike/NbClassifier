namespace NbClassifier.Model
{
    public interface INaiveBayesClassifier
    {
        int DetermineCategory(string document);
        void Train(string document, int category);
    }
}