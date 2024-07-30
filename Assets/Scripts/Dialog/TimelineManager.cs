using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector director1;
    public PlayableDirector director2;

    void Start()
    {
        // Start the first timeline
        director1.Play();

        // Subscribe to the played director's event
        director1.stopped += OnDirector1Finished;
    }

    private void OnDirector1Finished(PlayableDirector director)
    {
        if (director == director1)
        {
            // Start the second timeline when the first one finishes
            director2.Play();
        }
    }

    void OnDestroy()
    {
        // Always good to unsubscribe when the object is destroyed
        director1.stopped -= OnDirector1Finished;
    }
}
