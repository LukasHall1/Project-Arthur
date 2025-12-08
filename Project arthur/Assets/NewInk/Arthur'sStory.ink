VAR courage = 0
VAR humility = 0

-> start
=== start ===
You are Arthur, a young farmhand on the outskirts of Sir Ector's holdings. 
Dawn breaks over the rolling fields as you finish your morning chores.

Your foster brother Kay calls from the stable. 
"Arthur! Father wants you. Something about the tournament in London."

+ "I hurry to Sir Ector." -> meet_ector
+ "Kay can wait. I finish my chores first." 
    ~ humility += 1
    -> finish_chores

=== finish_chores ===
You linger a little longer, stacking the hay neatly. 
Sir Ector eventually appears behind you, arms folded.

"Responsible as ever," he says with a smile. 
"But we must speak of something important."

-> meet_ector

=== meet_ector ===
Sir Ector sits you down by the hearth.

"There is to be a great tournament in London," he explains. 
"Lords from across the realm will attend. A chance for Kay to earn his place as a knight."

He looks at you thoughtfully.  
"Arthur I want you to serve as Kay's squire."

+ "I would be honored." 
    ~ humility += 1
    -> accept_squire
+ "A squire? Truly? I won't let you down." 
    ~ courage += 1
    -> accept_squire
+ "I’m not sure I’m worthy of such a role…" 
    ~ humility += 1
    -> doubt_squire

=== doubt_squire ===
Sir Ector places a firm hand on your shoulder.

"Worthiness is not born of blood, but of deeds. You'll grow into the role."

-> accept_squire

=== accept_squire ===
Kay claps you on the back. "You'll carry my gear, polish my sword, prepare my horse, simple enough."

Sir Ector: "We leave at first light. Rest now, Arthur. Tomorrow your life begins anew."

-> journey_to_london

=== journey_to_london ===
The road to London winds through forests and villages. 
Merchants chatter about the tournament. Rumors swirl:  
"Whoever draws the sword from the stone shall be king of Britain."

Kay scoffs. "Fairy tales."

As night falls, your campfire flickers. A hooded stranger approaches.

"May I sit?" the stranger asks.

+ "Yes, join us." 
    ~ humility += 1
    -> meet_merlin
+ "Stay back. Who are you?" 
    ~ courage += 1
    -> meet_merlin
+ "I ignore him and focus on the fire." -> ignore_merlin

=== meet_merlin ===
The stranger lowers his hood. It is an elderly man with sharp, knowing eyes.

"Arthur," he says, though you never gave your name. 
"You tread a path that few can see, but many will follow."

Kay stares. "Do I know you?"

"I know many things," the man replies.  
"Especially of boys who doubt their place in the world."

He vanishes in a small swirl of smoke.

Kay: "What in the blazes!"

-> arrival_london

=== ignore_merlin ===
The stranger smiles softly.

"Another time, then."

When you glance up again, he is gone.

Kay: "Strange folk on the roads these days."

-> arrival_london

=== arrival_london ===
London is alive with banners and crowds.  
Trumpets blare as knights parade through the streets.

Sir Ector turns to Kay. "Prepare yourself. The lists open soon."

Kay pats his side, suddenly pale.  
"Arthur! my sword. I left it at the inn!"

Sir Ector frowns. "Arthur, fetch it at once!"

+ "I'll go get it!." 
    ~ courage += 1
    -> find_sword
+ "I try to calm Kay first." 
    ~ humility += 1
    -> calm_kay

=== calm_kay ===
You place a hand on Kay’s shoulder.  
“It’s alright. I’ll fix this.”

Kay exhales. "You're a good brother."

-> find_sword

=== find_sword ===
You sprint through the crowded streets back toward the inn.  
Halfway there, you realize: everyone is at the tournament.
the inn is locked. The sword is inside.

As this revelation washes over you dissapointment swells.
How will Kay perform in the tournament without a sword?
You plod your way back towards the tournament grounds, hesitant to break the news.
As you walk through a church courtyard you spy something odd.

A sword stands embedded in a stone, sunlight shimmering on its hilt.

A plaque reads: "Whosoever pulleth this sword from this stone is the rightful king of Briton."

+ "I should look closer" -> examine_stone
+ "Ignore it. Kay needs his sword." -> ignore_stone

=== ignore_stone ===
You turn away, determined to find a solution for this conundrum.  
But something tugs at your mind, a whisper:

"Arthur..."

The pull is irresistible.
You must look at that sword.

-> examine_stone

=== examine_stone ===
You approach the sword. No guards. No crowd. The bustle of the tournament far away now.

Your hand trembles as you reach for the hilt.

+ "I grip the sword firmly." 
    ~ courage += 1
    -> pull_sword
+ "I hesitate. Who am I to try this?" 
    ~ humility += 1
    -> hesitate_sword

=== hesitate_sword ===
A warm breeze circles you, no wind elsewhere.

A familiar voice murmurs:  
"Worthiness is not in birth, but deed."

It sounds like the hooded stranger from the road.

You place both hands on the hilt.

-> pull_sword

=== pull_sword ===
The moment your fingers wrap around the hilt, light ripples across the courtyard.

The sword slides free as though it were placed there only moments before.

You hold it in your hands.

+ "Return to Kay posthaste"
    ~ humility += 1
    ->return_to_Kay
+ "Tell Sir Ector about the sword"
    ~ courage += 1
    ->tell_SirEctor

=== return_to_Kay ===
You dash up to your brother in his tent and look to hand him the sword.
"Where did you get this? This isn't my sword." Kay looks a little cross.

"Well I found it" you say.

"This is far to fancy to just be something you found, did you steal it?"
"No!" your face bunches into a frown. "It was in a stone and I pulled it out!"

Sir Ector enters the tent in that moment and looks upon the sword, he gasps.
"Arthur show me where you've retrieved this sword from this instant."

+ "Take him to the stone"
    ->the_Stone
    
=== tell_SirEctor ===
Before you give this sword to Kay you figure it's best to make sure it's a good one.
Sir Ector knows his swords so you run to find him.

Once you found him you proffer the sword to Sir Ector.
"What incredible craftsmanship, and the blade is as keen as the day it was forged!" Sir Ector remarks.
"So it's a good sword?" you ask
"Indeed, and not Kay's Arthur. Where have you found this?"

+ "I found it in a stone"
    ->the_Stone
    
=== the_Stone ===

Bystanders heard your story and see the sword held.
They follow you, by the time you reach the church courtyard a veritable crowd has drawn behind you, Kay, and Sir Ector; whispering to themselves. "He drew the sword, a boy? king of Briton? It's just an elaborate ploy"
You reach the courtyard and find the stone empty.
Sir Ector returns the sword to the stone, a couple of knights had followed behind thinking this a very amusing trick. They try their best to pull the sword from the stone to no avail. Kay even tried his hand but it is stuck fast.
You however walk up to the sword and lay a single hand on it, the light ripples across the courtyard again and it slides free as though it had never been placed there.

Sir Ector falls to his knees "My God, Arthur you..."
Kay's jaw agape "Arthur? You're... king?"

The crowd erupts. "The boy is king! A boy cannot be a king!"

The cloaked stranger appears behind the stone with a loud bang.
"This boy is the rightful king of Briton!" He grasps your arm with the sword and lifts high. "All hail Arthur Pendragon! King of Briton."

 -> Ending
 
=== Ending ===
{courage > humility: You raise the sword high, unafraid of this sudden change. Ready to brazenly accept your destiny as King of Briton. }
{humility > courage: Merlin raises your sword high. You look around at the crowd, your father and brother, and think; How can you best serve the people of Briton?}

-> DONE
