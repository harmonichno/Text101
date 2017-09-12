using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TextController : MonoBehaviour {

	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, // scene - cell
						 corridor_0, stairs_0, floor, closed_door, stairs_1, corridor_1, in_closed_door, corridor_2, stairs_2, corridor_3, courtyard}; // scene - corridor

	private States currentState_;

	public Text text_;

	// Use this for initialization
	void Start () {
		currentState_ = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState_ == States.cell) 				{ state_cell(); }
		else if(currentState_ == States.mirror) 		{ state_mirror(); }
		else if(currentState_ == States.lock_0) 		{ state_lock_0(); }
		else if(currentState_ == States.sheets_0) 		{ state_sheets_0(); }
		else if(currentState_ == States.cell_mirror) 	{ state_cell_mirror(); }
		else if(currentState_ == States.sheets_1) 		{ state_sheets_1(); }
		else if(currentState_ == States.lock_1) 		{ state_lock_1(); }
		else if(currentState_ == States.corridor_0) 	{ state_corridor_0(); }
		else if(currentState_ == States.stairs_0) 		{ state_stairs_0(); }
		else if(currentState_ == States.floor) 			{ state_floor(); }
		else if(currentState_ == States.closed_door) 	{ state_closed_door(); }
		else if(currentState_ == States.corridor_1) 	{ state_corridor_1(); }
		else if(currentState_ == States.stairs_1) 		{ state_stairs_1(); }
		else if(currentState_ == States.in_closed_door) { state_in_closed_door(); }
		else if(currentState_ == States.corridor_2) 	{ state_corridor_2(); }
		else if(currentState_ == States.stairs_2) 		{ state_stairs_2(); }
		else if(currentState_ == States.corridor_3) 	{ state_corridor_3(); }
		else if(currentState_ == States.courtyard) 		{ state_courtyard(); }
	}

	// CELL SCENE

	void state_cell () {
		text_.text = "You are in prison cell, and you want to esacpe. There are " + 
					 "some dirty sheets on the bed, a mirror on the wall, and the door " + 
					 "is locked from the outside.\n\n" + 
				  	 "Press S to view Sheets, M to view Mirror and L to view Lock";

		if(Input.GetKeyDown(KeyCode.S)) {
			currentState_ = States.sheets_0; 
		}
		else if(Input.GetKeyDown(KeyCode.M)) {
			currentState_ = States.mirror; 
		}
		else if(Input.GetKeyDown(KeyCode.L)) {
			currentState_ = States.lock_0; 
		}
	}

	void state_mirror () {
		text_.text = "Oh. I see cell mirror. \n\n" + 
					 "Press T to Take mirror. Press R to Return";

		if(Input.GetKeyDown(KeyCode.T)) {
			currentState_ = States.cell_mirror;
		}
		else if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.cell;
		}
	}
	
	void state_lock_0 () {
		text_.text = "Yeah really locked.\n\n" + 
					 "Press R to Return";

		
		if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.cell;
		}
	}

	void state_sheets_0 () {
		text_.text = "I got sheet, need to do something\n\n" + 
					 "Press R to Return";
		
		if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.cell;
		}
	}

	void state_cell_mirror () {
		text_.text = "Hmm. Cell Mirror.\n\n" + 
		      		 "Press S to view Sheets. Press L to Lock door.";
		
		if(Input.GetKeyDown(KeyCode.S)) {
			currentState_ = States.sheets_1;
		}
		else if(Input.GetKeyDown(KeyCode.L)) {
			currentState_ = States.lock_1;
		}
	}

	void state_sheets_1 () {
		text_.text = "Sorry bro ! Sheets is empty.\n\n" + 
					 "Press R to Return !";
			
		if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.cell_mirror;
		}
	}

	void state_lock_1 () {
		text_.text = "Yeah  bro ! Door is opened.\n\n" + 
					 "Press O to Open. Press R to Return !";

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.cell_mirror;
		}
		else if(Input.GetKeyDown(KeyCode.O)) {
			currentState_ = States.corridor_0;
		}
	}
	
	// CORRIDOR SCENE

	void state_corridor_0 () {
		text_.text = "You are free ! Oh no, you are in corridor. \n\n" + 
					 "Press S to view Stairs, C to Come close to door and F to look Floor";
		
		if(Input.GetKeyDown(KeyCode.S)) {
			currentState_ = States.stairs_0;
		}
		else if (Input.GetKeyDown(KeyCode.C)) {
			currentState_ = States.closed_door;
		}
		else if (Input.GetKeyDown(KeyCode.F)) {
			currentState_ = States.floor;
		}
	}

	void state_stairs_0 () {
		text_.text = "I am mha sorry. There is nothing.\n\n" + 
					 "Press R to Return";
		
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState_ = States.corridor_0;
		}
	}

	void state_floor () {
		text_.text = "Floor as floor. Interesting thing is there !\n\n" + 
					 "Press H to take Hairclip. Press R to Return !";

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.corridor_0;
		}
		else if(Input.GetKeyDown(KeyCode.H)) {
			currentState_ = States.corridor_1;
		}
	}

	void state_closed_door () {
		text_.text = "Door is closed ! Shit !.\n\n" + 
					 "Press R to Return !";

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.corridor_0;
		}
	}

	void state_corridor_1 () {
		text_.text = "Now I can  try to unlock door and pick dress clothes. Wait... there are stairs. \n\n" + 
					 "Press P to Pick clothes. Press S to run on Stairs.";

		if(Input.GetKeyDown(KeyCode.S)) {
			currentState_ = States.stairs_1;
		}
		else if(Input.GetKeyDown(KeyCode.P)) {
			currentState_ = States.in_closed_door;
		}
	}
	
	void state_stairs_1 () {
		text_.text = "Stairs are broken. \n\n" + 
					 "Press R to Return.";
		
		if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.corridor_1;
		}
	}

	void state_in_closed_door () {
		text_.text = "This t-shirt is really swag. I can dress it. But there can some check also. \n\n" +
					 "Press C to Check corridor. Press D to Dress up clothes.";
		
		if(Input.GetKeyDown(KeyCode.C)) {
			currentState_ = States.corridor_2; 
		}
		else if(Input.GetKeyDown(KeyCode.D)) {
			currentState_ = States.corridor_3; 
		}
	}
	
	void state_corridor_2 () {
		text_.text = "I see lighs there. Go go go.\n\n" + 
					 "Press S to run to Stairs. Press R to Return !";
		

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.in_closed_door;
		}
		else if(Input.GetKeyDown(KeyCode.S)) {
			currentState_ = States.stairs_2;
		}
	}

	void state_stairs_2 () {
		text_.text = "Stairs are broken. Go away !.\n\n" + 
					 "Press R to Return !";

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState_ = States.corridor_2;
		}
	}

	void state_corridor_3 () {
		text_.text = "You are right.\n\n" + 
					 "Press U to Undress. Press S to run on Stairs !";
	
		if(Input.GetKeyDown(KeyCode.U)) {
			currentState_ = States.in_closed_door;
		}
		else if(Input.GetKeyDown(KeyCode.S)) {
			currentState_ = States.courtyard;
		}
	}

	void state_courtyard () {
		text_.text = "I am freedom as bird in the sky ! \n\n" + 
					 "Press R to Restart game !";
		
		if(Input.GetKeyDown(KeyCode.R)) {
			Start();
		}
	}
}
