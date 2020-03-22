using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Setting up the "Dialogue" object
//these dialogue objects will go in an array
//and it's various parts will be called upon by the text boxes
public class Dialogue
{

	public string speaker;

	public string dialogue;

	int[] nextOptions;

	public int responseIndex;


	public Dialogue(string speaker, string dialogue, int [] nextOptions){
		this.speaker = speaker;
		this.dialogue = dialogue;
		this.nextOptions = nextOptions;

	}
	public Dialogue(string speaker, string dialogue, int [] nextOptions, int responseIndex){
		this.speaker = speaker;
		this.dialogue = dialogue;
		this.nextOptions = nextOptions;
		this.responseIndex = responseIndex;
	}

	public int[] GetNextArray () {
		return nextOptions;
	}
	public int GetNextArray ( int index) {
		return nextOptions[index];
	}
	public int GetNextOptions (int index){
		return nextOptions[index];
	}

}

//main code
public class DialogueScript : MonoBehaviour
{
	//dialoguepath will contain all dialogue objects
	public Dialogue[] dialoguePath;
	//currIndex tells the boxes which dialogue to show
	//it is static so that the buttons can access it from their own script
	public static int currIndex;
	//text for main dialogue
	public Text DateDialogue;

	//text for dialogue options
	public Text Option1;
	public Text Option2;
	public Text Option3;
	public Text Option4;

	public GameObject YourWindow;
	public GameObject DateWindow;
	//text for speaker name
	public Text DateName;
	private bool yourTurn;
	private bool youreNext;

    public float timer;

    private grabbyFork grabbyFork;

    public AudioSource princeVoice, cringeSound;

	//objects for when the date is over
	public GameObject PRINCE;
	public GameObject PRINCEtext;

	//variables for detecting strikes
	public bool thinIceChewing;
	public bool thinIceDirty;
	public bool thinIceSpilling;
	public bool thinIceSilent;
	public int storedIndex;
	public float responseTimer;
	public GameObject PRINCEICON;

	//printing dialogue 
	public bool isPrinting;
	public int letterIndex;

	public int currentNoise;

    public Slider responseSlider;
    public Image princeIcon;
    private Animation iconAnim;

	public bool princeGone;

	// Start is called before the first frame update
	void Start()
	{

        iconAnim = princeIcon.GetComponent<Animation>();

        grabbyFork = FindObjectOfType<grabbyFork>();
		isPrinting = true;
		letterIndex = 1;
		currIndex = 0;

		thinIceChewing = false;
		thinIceSpilling = false;
		thinIceSilent = false;
		thinIceDirty = false;
		currentNoise = 0;
		/*Dont forget to increase array size if you add more dialogue nodes, remember
		that it should be one more than the highest node index number, because the nodes
		start with 0 and the array size does not
		*/
		dialoguePath = new Dialogue[500];

		/*fill array with all dialogue, the parameters of the dialogue class are
		name of speaker, dialogue text, and next dialogue options
		in that order
		*/
		//Da Rules: if the date needs more than one box to continue their speech, simply make all next options lead to their next box
		// 			if the dialogue object is You speaking, include an aditional paramenter that is the appropriate responses' index as an int
		dialoguePath [0] = new Dialogue ("The Prince", 
			"Hello! Yes, it is I, Prince Horatio VIII of the Empire of Janicula.", 
			new int[] {106,106,106,106});
		dialoguePath [1] = new Dialogue ("The Prince", 
			"But you can just call me… The Prince.",
			new int[] { 2, 3, 4, 5 });
		dialoguePath [2] = new Dialogue ("You", 
			 "That's one impressive introduction.",
			new int[] {7,7,7,7}, 7);
		dialoguePath [3] = new Dialogue ("You",
			 "Wow. That was like, so pretentious.",
			new int[] {58,58,58,58}, 58);
	
		dialoguePath [4] = new Dialogue ("You",
			"Am I supposed to care about all that?",
			new int[] {86,86,86,86}, 86);
		//5 is null on purpose
		dialoguePath [6] = new Dialogue ("The Prince",
			"AHE",
			new int[] {4,4,4,5});
		dialoguePath [7] = new Dialogue ("The Prince",
			" Well it’s usually my servants who announce my presence.",
			new int[] { 8, 8, 8, 8 });
		dialoguePath [8] = new Dialogue ("The Prince", 
			"They take so much delight in their fanfare, I suppose it’s rubbed off on me.",
			new int[] { 9, 9, 9, 9 });
		dialoguePath [9] = new Dialogue ("The Prince", 
			" I told them to leave me be, for I would be dining with one who is... unacustomed.",
			new int[] { 10, 10, 10, 10 });
		dialoguePath [10] = new Dialogue ( "The Prince",
			"But alas! They are likely hidden about, spying on my every move- against my wishes.",
			new int[] {11,12,54,55});
		dialoguePath [11] = new Dialogue ( "You",
			"Yikes, that sounds annoying.",
			new int[] {13,13,13,13}, 13);
		dialoguePath [12] = new Dialogue ("You",
			"I'm sure they mean well",
			new int[] { 85, 85, 85, 85 }, 85);
		dialoguePath [13] = new Dialogue ("The Prince",
			"Well yes, I suppose they can be quite annoying, but they don’t know any better.",
			new int[] { 14, 14, 14, 14 });
		dialoguePath [14] = new Dialogue ( "The Prince",
			"They’re part of a…I believe the term would be “lesser” species.",
			new int[] {15,15,15,15});
		dialoguePath [15] = new Dialogue ( "The Prince",
			" You see, they’re prisoners of war from the nation of Friendliness that my father had hypnotized and enslaved.",
			new int[] {16,16,16,16});
		dialoguePath [16] = new Dialogue ( "The Prince",
			"So their ignorance really isn’t their fault.",
			new int[] {17,18,20,19});
		dialoguePath [17] = new Dialogue ( "You",
			"The nation of… Friendliness?",
			new int[] {21,21,21,21}, 21);
		dialoguePath [18] = new Dialogue ( "You",
			"Why are you at war?",
			new int[] {25,25,25,25}, 25);
		dialoguePath [20] = new Dialogue ("You",
			"Friendliness... those fiends.",
			new int[] { 68, 68, 68, 68 }, 68);
		//20 is null on purpose
		dialoguePath [21] = new Dialogue ( "The Prince",
			"Ah, I recognize that look in your face.",
			new int[] {22,22,22,22});
		dialoguePath [22] = new Dialogue ( "The Prince",
			"You’re worried that the Friendly people are innocent and my father is committing these atrocities for no reason.",
			new int[] {23,23,23,23});
		dialoguePath [23] = new Dialogue ( "The Prince",
			"If you think they are innocent, I can assure you that they are not.",
			new int[] {24,24,24,24});
		dialoguePath [24] = new Dialogue ( "The Prince",
			"The Janicula empire has been at war with the Friendly people for generations.",
			new int[] {25,25,25,25});
		dialoguePath [25] = new Dialogue ( "The Prince",
			"They dared to secede from our perfect nation!",
			new int[] {107,107,107,107});
		dialoguePath [26] = new Dialogue ( "The Prince",
			"Can you imagine?",
			new int[] {27,28,29,30});
		dialoguePath [27] = new Dialogue ( "You",
			"That sounds pretty tyranical.",
			new int[] {69,69,69,69}, 69);
		dialoguePath [28] = new Dialogue ( "You",
			"If they saw your nation now, they’d come crawling back.",
			new int[] {31,31,31,31}, 31);
		dialoguePath [29] = new Dialogue ( "You",
			"Maybe you could come to a compromise?",
			new int[] {118,118,118,118}, 118);
		//30 is null on purpose
		dialoguePath [31] = new Dialogue ( "The Prince",
			" I’m glad you believe so. We work tirelessly in our quest for greatness.",
			new int[] {32,32,32,32});
		dialoguePath [32] = new Dialogue ( "The Prince",
			"My father is so tied up that I have a hand in certain affairs.",
			new int[] {33,33,33,33});
		dialoguePath [33] = new Dialogue ( "The Prince ",
			"Anyways, I tire of speaking on political matters.",
			new int[] {34,34,34,34});
		dialoguePath [34] = new Dialogue ( "The Prince",
			"What else would you like to talk about?",
			new int[] {35,36,37,38});
		dialoguePath [35] = new Dialogue ( "You",
			"Tell me about yourself.",
			new int[] {39,39,39,39}, 39);
		dialoguePath [36] = new Dialogue ( "You",
			"Well, I've had kind of an interesting day,",
			new int[] {76,76,76,76}, 76);
		dialoguePath [37] = new Dialogue ( "You",
			"Do you have siblings?",
			new int[] {89,89,89,89}, 89);
		
		//38 is null on purpose
		dialoguePath [39] = new Dialogue ( "The Prince",
			"Oh, I would love to.",
			new int[] {40,40,40,40});
		dialoguePath [40] = new Dialogue ( "The Prince",
			"On my leisure, I enjoy taking long horse rides through the plains. ",
			new int[] {41,41,41,41});
		dialoguePath [41] = new Dialogue ( "The Prince",
			"Occasionally, I enjoy visiting the royal dungeon and choosing which traitor will be next to be executed.",
			new int[] {42,42,42,42});
		dialoguePath [42] = new Dialogue ( "The Prince",
			"Recently, I’ve also been learning to crochet. It’s very therapeutic.",
			new int[] {43,44,45,46});
		dialoguePath [43] = new Dialogue ( "You",
			"Just gonna, gloss by your lust for killing?",
			new int[] {77,77,77,77},77);
		dialoguePath [44] = new Dialogue ( "You",
			"It sounds like your life is pretty stressful.",
			new int[] {47,47,47,47}, 47);
		dialoguePath [45] = new Dialogue ("You",
			"It seems like you enjoy killing.",
			new int[] { 119, 119, 119, 119 }, 119);
		//46 is null on purpose
		dialoguePath [47] = new Dialogue ( "The Prince",
			"You wouldn’t even begin to understand the amount of pressure I’m put through.  ",
			new int[] {48,48,48,48});
		dialoguePath [48] = new Dialogue ( "The Prince",
			"Believe it or not, I long to live in a society where I can just sit down and eat dinner with a peasant like you.",
			new int[] {49,49,49,49});
		dialoguePath [49] = new Dialogue ( "The Prince",
			"I know that, on the surface, I seem to obsessively indulge in formalities and overt egotism. ",
			new int[] {50,50,50,50});
		dialoguePath [50] = new Dialogue ( "The Prince",
			"And, internally, I also obsessively indulge in formalities and overt egotism.",
			new int[] {51,51,51,51});
		dialoguePath [51] = new Dialogue ( "The Prince",
			"But eating with you has made me realize something important.",
			new int[] {52,52,52,52});
		dialoguePath [52] = new Dialogue ( "The Prince",
			"Love can bloom between anyone, even a peasant and a handsome prince.",
			new int[] {53,53,53,53});
		dialoguePath [53] = new Dialogue ( "The Prince",
			"That is, as long as both people can finish their meals by the end of a date. Otherwise, why bother?",
			new int[] {56,56,56,56});
		//54 is null on purposee
		//55 is null on purpose
		//if you talk while chewing
	
        
		dialoguePath [58] = new Dialogue ("The Prince",
			"It may seem pretentious to a prole such as yourself, but these formalities are necesarry.",
			new int[] { 59, 59, 59, 59 });
		dialoguePath [59] = new Dialogue ("The Prince",
			"It's important for everyone to understand exactly how important I am.",
			new int[] { 60, 60, 60, 60 });
		dialoguePath [60] = new Dialogue ("The Prince",
			"ESPECIALLY in comparison to how unimportant you are.",
			new int[] { 61, 62, 63, 64 });
		dialoguePath [61] = new Dialogue ("You",
			"I just absolutely do not care.",
			new int[] { 65, 65, 65, 65 }, 65);
		dialoguePath [62] = new Dialogue ("You",
			"I'm sorry, I didn't know what I was saying.",
			new int[] { 66, 66, 66, 66 },66);
		//63 is null on purpose
		//64 is null on purpose
		dialoguePath [65] = new Dialogue ("The Prince",
			"Well, then it seems we have no buisness here.",
			new int[] { 6, 6, 6, 6});
		
		dialoguePath [66] = new Dialogue ("The Prince",
			"You most definitely did not.",
			new int[] { 67, 67, 67, 67});
		
		dialoguePath [67] = new Dialogue ("The Prince",
			"I'm already stressed because of the war with the nation of Friendliness.",
			new int[] { 17, 18, 20, 19});
		
		dialoguePath [68] = new Dialogue ("The Prince",
			"Oh trust me, I know all too well. Friendliness is a weak nation with even weaker denizens.",
			new int[] { 24, 24, 24, 24});
		dialoguePath [69] = new Dialogue ("The Prince",
			"You don't know what you're talking about. I'm the prince of a nation and you are a simple nobody.",
			new int[] { 70, 70, 70, 70});
		dialoguePath [70] = new Dialogue ("The Prince",
			"How is anything supposed to get done without mind controlled war prisoner slaves, I ask?",
			new int[] { 108, 108, 108, 108});
		dialoguePath [71] = new Dialogue ("You",
			"You would.",
			new int[] { 75, 75, 75, 75 },75);
		dialoguePath [72] = new Dialogue ("You",
			"Oh, I hadn't thought about it like that.",
			new int[] { 95, 95, 95, 95 },95);
		//73 is null on purpose
		//74 is null on purpose
		dialoguePath [75] = new Dialogue ("The Prince",
			"I will not sit here and be insulted. Good Day. Actually, have a BAD day. Good Day.",
			new int[] { 6, 6, 6, 6});
		dialoguePath [76] = new Dialogue ("The Prince",
			"Oh, I garuntee I won't care. Let's talk about me instead.",
			new int[] { 40, 40, 40, 40});
		dialoguePath [77] = new Dialogue ("The Prince",
			"I could try and explain it to you, but you'd never understand.",
			new int[] {78,78,78,78});
		dialoguePath [78] = new Dialogue ("The Prince",
			"Executions are completely necesarry to keep my people in line. It's not like it's murder, they have broken the law.",
			new int[] {79,79,79,79});
		dialoguePath [79] = new Dialogue ("The Prince",
			"If you don't want to die, don't do the crime. Isn't that what they say?",
			new int[] {80,81,82,83});
		dialoguePath [80] = new Dialogue ("You",
			"That's... apalling.",
			new int[] {75,75,75,75}, 75);
		dialoguePath [81] = new Dialogue ("You",
			"I guess that makes sense.",
			new int[] {84,84,84,84} , 84); 
		dialoguePath [84] = new Dialogue ("The Prince",
			"Being the prince is a tremendous responsiblity, you know. Its not all fun and games.",
			new int[] {47,47,47,47});
		dialoguePath [85] = new Dialogue ("The Prince",
			"Maybe they do, but thats no excuse for inconveniencing me.",
			new int[] {14,14,14,14});
		dialoguePath [86] = new Dialogue ("The Prince",
			"Yes. You are.",
			new int[] {87,87,87,87});
		dialoguePath [87] = new Dialogue ("The Prince",
			"Maybe the Janicula empire isn't a big deal in whatever quaint little hamlet you grew up in, but I assure you it is.",
			new int[] {88,88,88,88});
		dialoguePath [88] = new Dialogue ("The Prince",
			"The nuances of the throne are perhaps a little too complicated for someone of your... intelligence.",
			new int[] {115,115,115,115});
		dialoguePath [89] = new Dialogue ("The Prince",
			"Once upon a time, yes. But we all had to fight to the death over the right to rule.",
			new int[] {90,90,90,90});
		dialoguePath [90] = new Dialogue ("The Prince",
			"There was my brother, who was fine I suppose, but his sword could not reach past my spear. Clumsy fellow.",
			new int[] { 91, 91, 91, 91 });
		dialoguePath [91] = new Dialogue ("The Prince",
			"I also had a sister. She was good with a bow, but obviously not good enough.",
			new int[] { 116, 116, 116, 116 });
		dialoguePath [92] = new Dialogue ("You",
			"Why would anyone have multiple kids?",
			new int[] { 98, 98, 98, 98}, 98);
		dialoguePath [93] = new Dialogue ("You",
			"Your combat prowess is quite hot.",
			new int[] { 49, 49, 49, 49}, 49);
		
		//94 is nullo n purpose

		dialoguePath [95] = new Dialogue ("The Prince",
			"It seems you don't do much thinking in general.",
			new int[] { 96, 96, 96, 96});
		dialoguePath [96] = new Dialogue ("The Prince",
			"How could you even begin to understand the elgant affairs of the ruling class?",
			new int[] { 117, 117, 117, 117});
		dialoguePath [97] = new Dialogue ("The Prince",
			"I suppose we can talk about something else. What do um... you people like to talk about.",
			new int[] { 35, 36, 37, 38});
		
		dialoguePath [98] = new Dialogue ("The Prince",
			"Oh just for the drama of it. My father was the first one to have multiple children.",
			new int[] { 99, 99, 99, 99});
		dialoguePath [99] = new Dialogue ("The Prince",
			"He also invented the rule that we had to fight. They didn't expect me to win, being the youngest.",
			new int[] { 100, 100, 100, 100});
		dialoguePath [100] = new Dialogue ("The Prince",
			"You must think my father a monster. Well, he is.",
			new int[] { 101, 44, 103, 104});
		dialoguePath [101] = new Dialogue ("You",
			"That must really suck.",
			new int[] { 105, 105, 105, 105}, 105);
		//102 is null on purpose
		dialoguePath [103] = new Dialogue ("You",
			"Like father like son.",
			new int[] { 75, 75, 75, 75}, 75);
		dialoguePath [105] = new Dialogue ("The Prince",
			"I didn't think someone like you could understand me.",
			new int[] { 48, 48, 48, 48});


		//efforts to expand existing dialogue zone
		dialoguePath [106] = new Dialogue ("The Prince",
			"Son of Queen Yuveka and King Horatio VII, rightful heir to the land’s benevolent throne.",
			new int[] { 1, 1, 1, 1});
		dialoguePath [107] = new Dialogue ("The Prince",
			"Even, might I add, under the outstanding ruling of my great great great great great grandfather! Horatio!",
			new int[] { 26, 26, 26, 26});
		dialoguePath [108] = new Dialogue ("The Prince",
			"Who would polish the crown? Who would sweep the courtyard? Who would empty the chamber pots?",
			new int[] { 71, 72, 73, 74});
		//109 is handled in the update
		dialoguePath [110] = new Dialogue ("The Prince",
			"If you can't pay attention to my galliant, dashing words, then we have no buisness here. Good Day.",
			new int[] { 6, 6,6 , 6});
	
		//111 is not here on purpose
		//112 is not here on purpose
		//same to 114	
		dialoguePath [115] = new Dialogue ("The Prince",
			"Lets talk about something else.",
			new int[] { 35, 36,37 , 38});
		dialoguePath [116] = new Dialogue ("The Prince",
			"A moving man is a lot harder to hit than a still target. Good Times.",
			new int[] { 92, 93,94 , 94});
		dialoguePath [117] = new Dialogue ("The Prince",
			"War, glory, conquest, fear- foreign concepts to someone of your status.",
			new int[] { 97, 97,97 , 97});
		dialoguePath [118] = new Dialogue ("The Prince",
			"HA HA HA HA HA. Ohhh. I may have underestimated your wit. That was hilarious.",
			new int[] { 33, 33,33 , 33});
		
		dialoguePath [119] = new Dialogue ("The Prince",
			"It isn't the killing I enjoy. It's about a sense of nationalism.",
			new int[] { 120, 120,120 , 120});
		dialoguePath [120] = new Dialogue ("The Prince",
			"I feel closer to the nation when I am ridding her of... disturbances.",
			new int[] { 78, 78, 78 , 78});
	}

	// Update is called once per frame
	void Update()
	{

		//response timer 
					//this needs to be in the update so that the next array can constantly listen for changes in storedIndex
		dialoguePath [109] = new Dialogue ("The Prince",
			"Excuse me? Are you even listening to what I'm saying? I said...",
			new int[] { storedIndex, storedIndex, storedIndex, storedIndex});
		if (yourTurn == true) {

            responseSlider.gameObject.SetActive(true);

			responseTimer -= Time.deltaTime;
            responseSlider.value = responseTimer / 7;

			if (responseTimer <= 0 && thinIceSilent == true) {
				DateDialogue.text = dialoguePath [110].dialogue [0].ToString ();
				isPrinting = true;
				timer = 5f;
				currIndex = 110;
                iconAnim.Play();
            } else if (responseTimer <= 0 && thinIceSilent == false) {

					storedIndex = currIndex;

				DateDialogue.text = dialoguePath [109].dialogue [0].ToString ();
				isPrinting = true;
				currIndex = 109;
				thinIceSilent = true;
                cringeSound.Play();
                iconAnim.Play();
            }

		} 

		//talk food eat mouth full
		if (currIndex == 111) {
			thinIceChewing = true;
		}
		if (thinIceChewing == true) {
			dialoguePath [57] = new Dialogue ("The Prince", 
				"You are a slob... I must go at Once. ",
				new int[] { 6, 6, 6, 6});
			
		} else {
			dialoguePath [57] = new Dialogue ("The Prince", 
				"Im sorry- it distracts me when people think its acceptable to speak with their mouth full. ",
				new int[] { 111, 111, 111, 111 });


		}
		dialoguePath [111] = new Dialogue ("The Prince", 
			"Now what was I saying?... Oh yeah- ",
			new int[] { storedIndex, storedIndex, storedIndex, storedIndex });
	
		if (dialoguePath [dialoguePath[currIndex].GetNextArray(1)] != null) {
			
		}
        if (Input.GetKeyDown(KeyCode.Space))
            NextText();

		if (!youreNext && !yourTurn)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
                NextText();
        }

        if (currIndex >= 53)
        {
            if (grabbyFork.currentBits >= grabbyFork.bitsMax)
            {
                dialoguePath[56] = new Dialogue("The Prince",
           "I've had a wonderful time, call me!",
           new int[] { 6, 6, 6, 6 });
            } else
            {
                dialoguePath[56] = new Dialogue("The Prince",
            "You're going to waste the food you ordered? If you get a box, your steak will dry out. Goodbye- do not call me.",
            new int[] { 6, 6, 6, 6 });
            }
        }


		//keeps track of who is speaking
		if (isPrinting == false && dialoguePath[dialoguePath[currIndex].GetNextArray(1)] != null && dialoguePath[dialoguePath[currIndex].GetNextArray(1)].speaker.Equals ("You") || isPrinting == false && dialoguePath[currIndex].GetNextArray(1) - currIndex >= 5 && checkArraySame () == false|| isPrinting == false && dialoguePath[currIndex].GetNextArray(1) - currIndex <= -5 && checkArraySame () == false ) {
			yourTurn = true;

		} else {
			yourTurn = false;
		}
		//checks if you are next to speak (by checking if all next options are the same 
		//also, if it is youre turn, then youreNext is false
		if (checkArraySame () == true) {
			youreNext = false;

		} else if (yourTurn == true) {
			youreNext = false;

		} else {
			
			youreNext = true;
		}

		if (yourTurn == true) {
			YourWindow.SetActive (true);
		} else {
			YourWindow.SetActive (false);
		}

		//If you arent next to speak, your options do not show up
	
		//text is constantly updated to the current dialogue

		if (isPrinting == true) {
			if (DateDialogue.text.Length < 0) {
				DateDialogue.text = dialoguePath [currIndex].dialogue [0].ToString ();
			}
			if (DateDialogue.text.Length > 0) {
				DateDialogue.text +=  dialoguePath [currIndex].dialogue [letterIndex].ToString ();
				letterIndex++;
			}
			if (letterIndex >= dialoguePath [currIndex].dialogue.Length) {
				isPrinting = false;
				letterIndex = 1;
			}
		
		}
		//speaker name is also updated
		DateName.text = dialoguePath [currIndex].speaker;
		//option text is updated also, provided that it will not become null
		if (dialoguePath [dialoguePath [currIndex].GetNextOptions (0)] != null) {
			Option1.text = "1: " + dialoguePath [dialoguePath [currIndex].GetNextOptions (0)].dialogue;
		}
        if (dialoguePath[dialoguePath[currIndex].GetNextOptions(1)] != null)
        {
            Option2.text = "2: " + dialoguePath[dialoguePath[currIndex].GetNextOptions(1)].dialogue;
        }
		if (dialoguePath [dialoguePath [currIndex].GetNextOptions (2)] != null) {
			Option3.text = "3: " + dialoguePath [dialoguePath [currIndex].GetNextOptions (2)].dialogue;
		}
		if (dialoguePath [dialoguePath [currIndex].GetNextOptions (3)] != null) {
			Option4.text = "4: " + dialoguePath [dialoguePath [currIndex].GetNextOptions (3)].dialogue; 
		}
			
		//The Dialogue Choices are selected by using 1, 2, 3, and 4 keys
		//If any dialogue option is null, it is not shown.
		if (dialoguePath [dialoguePath [currIndex].GetNextOptions (0)] == null) {
			Option1.enabled = false;

		} else {
			Option1.enabled = true;
			if (Input.GetKeyDown (KeyCode.Alpha1) && yourTurn) {
				Option1Select ();

			}
		}
		if (dialoguePath [dialoguePath [currIndex].GetNextOptions (1)] == null) {
			Option2.enabled = false;

		} else {
			Option2.enabled = true;
			if (Input.GetKeyDown (KeyCode.Alpha2) && yourTurn) {
				Option2Select ();

			}
		}
		if (dialoguePath [dialoguePath [currIndex].GetNextOptions (2)] == null) {
			Option3.enabled = false;

		} else {
			Option3.enabled = true;
			if (Input.GetKeyDown (KeyCode.Alpha3) && yourTurn) {
				Option3Select ();

			}
		}
		if (dialoguePath [dialoguePath [currIndex].GetNextOptions (3)] == null) {
			Option4.enabled = false;

		} else {
			Option4.enabled = true;
			if (Input.GetKeyDown (KeyCode.Alpha4) && yourTurn) {
				Option4Select ();

			}
		}
	
	//code for ending date
		if (currIndex == 6) {
            PRINCE.GetComponent<Rigidbody>().isKinematic = false;
			PRINCE.GetComponent<Rigidbody> ().velocity = new Vector3 (20, 20, 20);
			PRINCEtext.SetActive (false);
			YourWindow.SetActive (false);
			PRINCEICON.SetActive (false);
		}
	

	
		//spill listener


		if (waterScript.noise == 2 && thinIceSpilling == false) {
			timer = 3f;
		
				storedIndex = currIndex;

			letterIndex = 1;
			dialoguePath [112] = new Dialogue ("The Prince", 
				"My, you're really ham fising that glass aren't you? Anyway...",
				new int[] { storedIndex, storedIndex, storedIndex, storedIndex });
			DateDialogue.text = dialoguePath [112].dialogue [0].ToString ();
			isPrinting = true;

			currIndex = 112;
			thinIceSpilling = true;
            cringeSound.Play();
            iconAnim.Play();
        }
		if (waterScript.noise == 4 && thinIceSpilling == true){
			timer = 3f;
			letterIndex = 1;
			dialoguePath [113] = new Dialogue ("The Prince", 
				"You can't properly drink can you?",
				new int[] { 114, 114, 114, 114 });
			dialoguePath [114] = new Dialogue ("The Prince", 
				"Why am I wasting my time on a tactless mongrel? I must go at once.",
				new int[] { 6, 6, 6, 6 });
			DateDialogue.text = dialoguePath [113].dialogue [0].ToString ();
			isPrinting = true;

			currIndex = 113;
			thinIceSpilling = false;
            iconAnim.Play();
        }

		//Debug.Log (grabbyFork.dirtyNoise);
		//Dirty Listener
		if (grabbyFork.dirtyNoise == 2 && thinIceDirty == false) { 
			timer = 3f;


				storedIndex = currIndex;

			letterIndex = 1;
			dialoguePath [112] = new Dialogue ("The Prince", 
				"Why don't you make use of your napkin? Anyway...",

				new int[] { storedIndex, storedIndex, storedIndex, storedIndex });
			currIndex = 112;
			grabbyFork.dirtyTimer = 0;
			DateDialogue.text = dialoguePath [112].dialogue [0].ToString ();
			isPrinting = true;
			thinIceDirty = true;
            cringeSound.Play();
            iconAnim.Play();
        }

		if (grabbyFork.dirtyNoise == 4 && thinIceDirty == true){
			timer = 3f;
			letterIndex = 1;
			dialoguePath [112] = new Dialogue ("The Prince", 
				"I really cannot stand the mess you've left on your face- I must go at once.",
				new int[] { 6, 6, 6, 6 });
			currIndex = 112;
			grabbyFork.dirtyTimer = 0;
			DateDialogue.text = dialoguePath [112].dialogue [0].ToString ();
			isPrinting = true;
			thinIceDirty = false;
            iconAnim.Play();
        }





	}

	public void Option1Select () {

			

		if (grabbyFork.chewing) {
			
				storedIndex = currIndex;
				
			iconAnim.Play();
			currIndex = 57;
			DateDialogue.text = dialoguePath [57].dialogue [0].ToString ();
			cameraController.strikes++;

			isPrinting = true;
		} else {
			currIndex = dialoguePath[dialoguePath [currIndex].GetNextOptions (0)].responseIndex;
			DateDialogue.text = dialoguePath [currIndex].dialogue [0].ToString ();
			isPrinting = true;
		}



    }
	public void Option2Select () {

			
		if (grabbyFork.chewing) {

				storedIndex = currIndex;
			
			iconAnim.Play();
			currIndex = 57;
			DateDialogue.text = dialoguePath [57].dialogue [0].ToString ();
			cameraController.strikes++;
			isPrinting = true;
		} else {
			currIndex = dialoguePath[dialoguePath [currIndex].GetNextOptions (1)].responseIndex;

			DateDialogue.text = dialoguePath [currIndex].dialogue [0].ToString ();
			isPrinting = true;
		}
    
    }
	public void Option3Select () {

			

		if (grabbyFork.chewing) {
			
				storedIndex = currIndex;

			iconAnim.Play();
			currIndex = 57;
			DateDialogue.text = dialoguePath [57].dialogue [0].ToString ();
			cameraController.strikes++;
			isPrinting = true;
		} else {
			currIndex = dialoguePath[dialoguePath [currIndex].GetNextOptions (2)].responseIndex;
			DateDialogue.text = dialoguePath [currIndex].dialogue [0].ToString ();
			isPrinting = true;
		}
    

    }
	public void Option4Select () {
		
	
		if (grabbyFork.chewing) {
			
				storedIndex = currIndex;

			iconAnim.Play();
			currIndex = 57;
			DateDialogue.text = dialoguePath [57].dialogue [0].ToString ();
			cameraController.strikes++;
			isPrinting = true;
		} else {
			currIndex = dialoguePath[dialoguePath [currIndex].GetNextOptions (3)].responseIndex;
			DateDialogue.text = dialoguePath [currIndex].dialogue [0].ToString ();
			isPrinting = true;
		}
   

    }
	public void NextText () {
        if (dialoguePath[dialoguePath[currIndex].GetNextOptions(0)] != null)
        {
			
            currIndex = dialoguePath[currIndex].GetNextOptions(0);
		
        }
	
	
        timer = 5f;
		responseTimer = 7f;
        princeVoice.Play();
		DateDialogue.text = dialoguePath [currIndex].dialogue [0].ToString ();
		isPrinting = true;

        responseSlider.value = 1;
	}

	public bool checkArraySame (){
		if (dialoguePath[dialoguePath[currIndex].GetNextOptions(0)] != null && dialoguePath[currIndex].GetNextOptions (0) == dialoguePath [currIndex].GetNextOptions (1) &&
		    dialoguePath [currIndex].GetNextOptions (0) == dialoguePath [currIndex].GetNextOptions (2) &&
		    dialoguePath [currIndex].GetNextOptions (0) == dialoguePath [currIndex].GetNextOptions (3)) {
			return true;
		} else {
			return false;
		}
	}

}

