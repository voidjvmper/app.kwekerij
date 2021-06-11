using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;
using Shop.Events;
using System.Linq;
using TimSort;

public class Garden : MonoBehaviour
{
    [SerializeField] Testbench testbench;
    [SerializeField] private int seed;
    [SerializeField] private Soil soil;
    [SerializeField] private Patch[] patches;
    //TODO: Replace
    [SerializeField] public Plant[] availableSpecies;
    [Range(0, 50)]
    [SerializeField] private int numberOfBeds;
    
    //private List<Bed> beds;
    private List<Bed> newBeds;
    private bool initialised = false;
    private int generationNumber = 0;
    private int givenIterations = 1;



    private int testingBase = 0;
    private int testingSet = 0;
    private int[] testSets = { 1, 1000, 10000 };

    private string testTitles = string.Empty;
    private string[] testTimes = { string.Empty, string.Empty, string.Empty };
    private string[] testFitnesses = { string.Empty, string.Empty, string.Empty };

    // Start is called before the first frame update
    void Start()
    {        
        GeneticEntity.SeedRandom(seed);
        
        soil = GetComponent<Soil>();
        newBeds = new List<Bed>();
        ResetPopulation(false);

        EventQueue.Subscribe(EventQueue.EventType.Plot_Start, EvolvePopulation);
        
    }

    private void OnDestroy()
    {
        EventQueue.Unsubscribe(EventQueue.EventType.Plot_Start, EvolvePopulation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //Analyse();
            
        }
    }

    public void RunGamut()
    {
        EventQueue.Subscribe(EventQueue.EventType.BroadcastGeneration, Ticker);
        ExtractTestTitles();
        CSVWriter.WriteHeader(testTitles);
        BeginTestingSession(false);
    }

    private void BeginTestingSession(bool shouldRecord)
    {
        int set = 0;
        int cross = 0;
        int pair = 0;
        int pool = 0;
        int mute = 0;

        mute = testingBase;
        pool = Mathf.FloorToInt(testingBase / ((int)Testbench.MutatorLoad.TOTAL));
        pair = Mathf.FloorToInt(pool / ((int)Testbench.MatingPoolSelectorLoad.TOTAL));
        cross = Mathf.FloorToInt(pair / ((int)Testbench.BreedingPairSelectorLoad.TOTAL));
        set = Mathf.FloorToInt(cross / ((int)Testbench.CrossoverOperatorLoad.TOTAL));
       

        if (set > testingSet)
        {
            Debug.Log("Done testing set " + testingSet + " | mute: " + mute + " | pool: " + pool + " | pair: " + pair + " | cross: " + cross );
            CSVWriter.WriteOne("times", testTimes[testingSet], testSets[testingSet].ToString());
            CSVWriter.WriteOne("fitnesses", testFitnesses[testingSet], testSets[testingSet].ToString());
        }
        testingSet = set;

        if (testingSet < testSets.Length)
        {
            //Set up testing bench
            testbench.SetCrossoverOperator( (Testbench.CrossoverOperatorLoad)(cross % (int)(Testbench.CrossoverOperatorLoad.TOTAL) ) );
            testbench.SetMatingPoolSelector( (Testbench.MatingPoolSelectorLoad)(pool % (int)(Testbench.MatingPoolSelectorLoad.TOTAL) ) );
            testbench.SetBreedingPairSelector( (Testbench.BreedingPairSelectorLoad)(pair % (int)(Testbench.BreedingPairSelectorLoad.TOTAL) ) );
            testbench.SetMutator( (Testbench.MutatorLoad) (mute %  (int)(Testbench.MutatorLoad.TOTAL) ) );



            

            ResetPopulation(true);
            StartEvolveProcess(testSets[set]);
        }
        else
        {
            EndGamut();
           // CSVWriter.WriteCSV(testTitles, testTimes[0], testTimes[1], testTimes[2], testFitnesses[0], testFitnesses[1], testFitnesses[2]);
        }
    }

    private void EndGamut()
    {
        EventQueue.Unsubscribe(EventQueue.EventType.BroadcastGeneration, Ticker);
    }
  

    private void Ticker(object sender, EventArgs e)
    {
        //save

        testTimes[testingSet] += TimeLogger.Elapsed + ", ";
        testFitnesses[testingSet] += newBeds[0].Fitness + ",";

        testingBase++;
        BeginTestingSession(true);

        //when recive broadcast end
        //record
        /*
         * pTimeString += TimeLogger.Elapsed + ", ";
        pFitnessString += newBeds[0].Fitness + ",";
        ResetPopulation(true);
        */
        //list 4++;
        //if list 4 % TOTAl == 0
        //list 3++

    }

    private void Analyse()
    {
        /*
         4 nested for loops

         */

        /*string titles = string.Empty;
        string times_1 = string.Empty;
        string times_1k = string.Empty;
        string times_10k = string.Empty;

        string fitness_1 = string.Empty;
        string fitness_1k = string.Empty;
        string fitness_10k = string.Empty;

        for (int c = 0; c < (int)(Testbench.CrossoverOperatorLoad.TOTAL) -1; c++)
        {
            for (int pools = 0; pools < (int)(Testbench.MatingPoolSelectorLoad.TOTAL) - 1; pools++)
            {
                for (int pairs = 0; pairs < (int)(Testbench.BreedingPairSelectorLoad.TOTAL) - 1; pairs++)
                {
                    for (int m = 0; m < (int)(Testbench.MutatorLoad.TOTAL) - 1; m++)
                    {
                        titles += 
                                  ((Testbench.CrossoverOperatorLoad)c).ToString() + "-" +
                                  ((Testbench.MatingPoolSelectorLoad)pools).ToString() + "-" +
                                  ((Testbench.BreedingPairSelectorLoad)pairs).ToString() + "-" +
                                  ((Testbench.MutatorLoad)m).ToString() + ", ";

                        //Set up the testbench
                        testbench.SetCrossoverOperator((Testbench.CrossoverOperatorLoad)c);
                        testbench.SetMatingPoolSelector((Testbench.MatingPoolSelectorLoad)pools);
                        testbench.SetBreedingPairSelector((Testbench.BreedingPairSelectorLoad)pairs);
                        testbench.SetMutator((Testbench.MutatorLoad)m);

                        //Run Once
                        RunGamut(1, ref times_1, ref fitness_1);

                        //Run 1k
                        RunGamut(1000, ref times_1k, ref fitness_1k);

                        //Run 10k
                        RunGamut(10000, ref times_10k, ref fitness_10k);
                    }
                }
            }
        }*/

        //CSVWriter.WriteCSV(titles, times_1, times_1k, times_10k, fitness_1, fitness_1k, fitness_10k);
    }

    private void ExtractTestTitles()
    {
        for (int c = 0; c < (int)(Testbench.CrossoverOperatorLoad.TOTAL) ; c++)
        {
            for (int pools = 0; pools < (int)(Testbench.MatingPoolSelectorLoad.TOTAL) ; pools++)
            {
                for (int pairs = 0; pairs < (int)(Testbench.BreedingPairSelectorLoad.TOTAL) ; pairs++)
                {
                    for (int m = 0; m < (int)(Testbench.MutatorLoad.TOTAL) ; m++)
                    {
                        testTitles +=
                                  ((Testbench.CrossoverOperatorLoad)c).ToString() + "-" +
                                  ((Testbench.MatingPoolSelectorLoad)pools).ToString() + "-" +
                                  ((Testbench.BreedingPairSelectorLoad)pairs).ToString() + "-" +
                                  ((Testbench.MutatorLoad)m).ToString() + ", ";

                    }
                }
            }
        }
    }

    private void RunGamut(int pIterations, ref string pTimeString, ref string pFitnessString)
    {
        /*StartEvolveProcess(pIterations);
        pTimeString += TimeLogger.Elapsed + ", ";
        pFitnessString += newBeds[0].Fitness + ",";
        ResetPopulation(true);*/
    }

    public void ResetPopulation(bool shouldResetSeed)
    {
        if (shouldResetSeed)
        {
            GeneticEntity.SeedRandom(seed);
        }
        newBeds.Clear();
        newBeds = CreateBeds();
        generationNumber = 0;
        EventQueue.QueueEvent(EventQueue.EventType.Plot_Reset, this, new TimeArgs(Time.realtimeSinceStartup));
    }

    //Subscribed to PlotStart, which is queued in UIReflect after UI updates (which is queued StartEvolve)
    private void EvolvePopulation(object sender, EventArgs e)
    {
        TimeLogger.LogStart();
        float averageFitness = 0.0f;

        List<Bed> evolvedBeds = new List<Bed>();
        
        //Actual Evolve process
        for (int g = 0; g < givenIterations; g++)
        {
            //New beds get inited from rand conditions for the first gen
            //Should ideally ahve already been done from Start -> ResetPopulation, just a safety measure
            if (!initialised)
            {
                newBeds = CreateBeds();
            }

            //The previous List gets emptied. This data is now stored in newBeds after the last generation
            if (initialised)
            {
                

            }

            /*for (int i = 0; i < beds.Count; i++)
            {
                beds[i].ComputeFitness();
            }*/
            if (evolvedBeds == null)
            {
                //Debug.Log("Evolved null");
            }
            if (newBeds == null)
            {
                //Debug.Log("new beds null");
            }

            //Use the GA to evolve our data
            evolvedBeds = GeneticEvolution.Evolve(newBeds, newBeds.Count, testbench.GetUsedMatingPoolSelector(),
                                                                          testbench.GetUsedBreedingPairSelector(),
                                                                          testbench.GetUsedCrossoverOperator(),
                                                                          testbench.GetUsedMutator());                                  

            for (int i = 0; i < evolvedBeds.Count; i++)
            {
                evolvedBeds[i].LoadGardenAndPatches(this, patches);
            }
            generationNumber++;

            //Debug.Log("Unsorted List " + beds[0].Fitness);
            Bed[] bedArray = evolvedBeds.ToArray();
            TimSort<Bed>.sort(bedArray, new GeneticEntityComparable());
            /* for (int i = 0; i < bedArray.Length; i++)
             {
                 Debug.Log("Sorted post-gen i: " + i + " Fitness: " + bedArray[i].Fitness);
             }*/
            //Debug.Log("Top of Array: " + bedArray[0].Fitness);
            evolvedBeds = new List<Bed>(bedArray);

            //Trimming the solutions
            //Debug.Log("Evolved Beds pre-trim - size: " + evolvedBeds.Count);

            //Certain Pair Selectors create larger numbers of solutions than the intial set of parents.
            //In this case, we require as many solutions (beds) as we put in and therefore remove the excess
            //after they've been fitness sorted
            if (evolvedBeds.Count > numberOfBeds)
            {
                evolvedBeds.RemoveRange(numberOfBeds - 1, (evolvedBeds.Count - numberOfBeds));
            }
            //Debug.Log("Evolved Beds post-trim - size: " + evolvedBeds.Count);


            averageFitness = 0.0f;
            for (int i = 0; i < evolvedBeds.Count; i++)
            {
                averageFitness += evolvedBeds[i].Fitness;
                // Debug.Log("Beds [" + i + "]:" + beds[i].Fitness);
            }
            averageFitness /= evolvedBeds.Count;            

            //Clear out the starting beds
            newBeds.Clear();

            //Save the evolved beds into a new starting List to be used for the next generation
            for (int i = 0; i < evolvedBeds.Count; i++)
            {
                newBeds.Add(evolvedBeds[i]);
            }

            //Clear out the evolved one
            evolvedBeds.Clear();

            //Debug.Log("End of gen loop - eb size: " + evolvedBeds.Count + " | nb: " + newBeds.Count);
        }


        TimeLogger.LogEnd();
        EventQueue.QueueEvent(EventQueue.EventType.Plot_End, this, new TimeArgs(Time.realtimeSinceStartup));
        //We use newBeds not evolvedBeds here since at the end of the gen, new holds the next (or last) generation's data
        //and evolved is already cleared for the next gen
        EventQueue.QueueEvent(EventQueue.EventType.BroadcastGeneration, this, new GenerationArgs<Bed>(newBeds, newBeds[0].Fitness, averageFitness, generationNumber, testingBase));

       
    }


    //Called from UI
    public void StartEvolveProcess(int pIterations)
    {
        givenIterations = pIterations;
        
        //
        EventQueue.QueueEvent(EventQueue.EventType.BroadcastBeginGenerating, this, new TimeArgs(Time.realtimeSinceStartup));
        
        //if !init
        //create
        //geneticevo.evolve
    }


    /*public void FillBeds(int[] pChromosome = null)
    {
        for (int i = 0; i < beds.Count; i++)
        {
            int[] chromosome = pChromosome == null ? GeneticEntity.GenerateRandomChromosome(new Vector2Int(0, 4), patches.Length, seed) : pChromosome;
            beds[i] = new Bed(chromosome, 0.0f, patches);
        }
    }*/

    public List<Bed> CreateBeds(int[] pChromosome = null)
    {
        
        List<Bed> firstBeds = new List<Bed>();
        for (int i = 0; i < numberOfBeds; i++)
        {
            Vector2Int alleleRange = new Vector2Int((int)testbench.AlleleLower, (int)testbench.AlleleUpper);
            int[] chromosome = pChromosome == null ? GeneticEntity.GenerateRandomChromosome(alleleRange, patches.Length, seed) : pChromosome;
            firstBeds.Add(new Bed(chromosome, alleleRange, this, patches));
        }
        initialised = true;
        //Debug.Log("Create " + firstBeds.Count + " beds.");
        return firstBeds;
    }

    public Soil Soil
    {
        get { return soil; }
    }
}
