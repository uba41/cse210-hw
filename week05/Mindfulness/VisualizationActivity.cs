class VisualizationActivity : Activity
{
    private List<string> _visualizations;

    public VisualizationActivity()
    {
        _name = "Welcome to the Visualization Activity";
        _description = "This activity will guide you through imagining a peaceful and calming scenario. Visualization can help reduce stress and improve focus by engaging your imagination in positive ways.";

        _visualizations = new List<string>
        {
            "Imagine you're walking through a peaceful forest. The leaves rustle gently in the breeze...",
            "Picture yourself lying on a warm beach, listening to the waves wash ashore...",
            "Visualize floating on a cloud, light and free from any worries...",
            "Imagine yourself achieving a goal you've been working toward...",
            "You are sitting beside a calm lake. The water is still. The air is fresh and cool..."
        };
    }

    private string GetRandomVisualization()
    {
        Random rand = new Random();
        return _visualizations[rand.Next(_visualizations.Count)];
    }

    public override void Run()
    {
        DisplayStartingMessage();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.WriteLine($"\n{GetRandomVisualization()}");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}