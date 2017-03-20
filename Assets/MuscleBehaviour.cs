using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class MuscleBehaviour : MonoBehaviour {

    public Rigidbody body, rightFrontFoot, rightBackFoot, leftFrontFoot, leftBackFoot;

    public Rigidbody rightFrontUpperHamstring, rightFrontLowerHamstring, rightBackUpperHamstring, rightBackLowerHamstring, 
        leftFrontUpperHamstring, leftFrontLowerHamstring, leftBackUpperHamstring, leftBackLowerHamstring;

    public Rigidbody rightFrontUpperChest, rightFrontLowerChest, rightBackUpperChest, rightBackLowerChest,
        leftFrontUpperChest, leftFrontLowerChest, leftBackUpperChest, leftBackLowerChest;

    public Rigidbody rightFrontUpperGluteus, rightFrontLowerGluteus, rightBackUpperGluteus, rightBackLowerGluteus,
        leftFrontUpperGluteus, leftFrontLowerGluteus, leftBackUpperGluteus, leftBackLowerGluteus;

    public Rigidbody rightFrontUpperGastro, rightFrontLowerGastro, rightBackUpperGastro, rightBackLowerGastro,
        leftFrontUpperGastro, leftFrontLowerGastro, leftBackUpperGastro, leftBackLowerGastro;

    public Rigidbody rightFrontUpperTibialis, rightFrontLowerTibialis, rightBackUpperTibialis, rightBackLowerTibialis,
        leftFrontUpperTibialis, leftFrontLowerTibialis, leftBackUpperTibialis, leftBackLowerTibialis;

    private Muscle rightFrontHamstring, rightBackHamstring, leftFrontHamstring, leftBackHamstring, rightFrontChest, rightBackChest, leftFrontChest, leftBackChest,
        rightFrontGluteus, rightBackGluteus, leftFrontGluteus, leftBackGluteus, rightFrontGastro, rightBackGastro, leftFrontGastro, leftBackGastro,
        rightFrontTibialis, rightBackTibialis, leftFrontTibialis, leftBackTibialis;

    private MuscleGroup hamstring, chest, gluteus, gastro, tibialis;

    public int t;

    // Use this for initialization
	void Start () {

        rightFrontHamstring = new Muscle(rightFrontUpperHamstring, rightFrontLowerHamstring);
        rightBackHamstring = new Muscle(rightBackUpperHamstring, rightBackLowerHamstring);
        leftFrontHamstring = new Muscle(leftFrontUpperHamstring, leftFrontLowerHamstring);
        leftBackHamstring = new Muscle(leftBackUpperHamstring, leftBackLowerHamstring);

        rightFrontChest = new Muscle(rightFrontUpperChest, rightFrontLowerChest);
        rightBackChest = new Muscle(rightBackUpperChest, rightBackLowerChest);
        leftFrontChest = new Muscle(leftFrontUpperChest, leftFrontLowerChest);
        leftBackChest = new Muscle(leftBackUpperChest, leftBackLowerChest);

        rightFrontGluteus = new Muscle(rightFrontUpperGluteus, rightFrontLowerGluteus);
        rightBackGluteus = new Muscle(rightBackUpperGluteus, rightBackLowerGluteus);
        leftFrontGluteus = new Muscle(leftFrontUpperGluteus, leftFrontLowerGluteus);
        leftBackGluteus = new Muscle(leftBackUpperGluteus, leftBackLowerGluteus);

        rightFrontGastro = new Muscle(rightFrontUpperGastro, rightFrontLowerGastro);
        rightBackGastro = new Muscle(rightBackUpperGastro, rightBackLowerGastro);
        leftFrontGastro = new Muscle(leftFrontUpperGastro, leftFrontLowerGastro);
        leftBackGastro = new Muscle(leftBackUpperGastro, leftBackLowerGastro);

        rightFrontTibialis = new Muscle(rightFrontUpperTibialis, rightFrontLowerTibialis);
        rightBackTibialis = new Muscle(rightBackUpperTibialis, rightBackLowerTibialis);
        leftFrontTibialis = new Muscle(leftFrontUpperTibialis, leftFrontLowerTibialis);
        leftBackTibialis = new Muscle(leftBackUpperTibialis, leftBackLowerTibialis);

        hamstring = new MuscleGroup(rightFrontHamstring, rightBackHamstring, leftFrontHamstring, leftBackHamstring);
        chest = new MuscleGroup(rightFrontChest, rightBackChest, leftFrontChest, leftBackChest);
        gluteus = new MuscleGroup(rightFrontGluteus, rightBackGluteus, leftFrontGluteus, leftBackGluteus);
        gastro = new MuscleGroup(rightFrontGastro, rightBackGastro, leftFrontGastro, leftBackGastro);
        tibialis = new MuscleGroup(rightFrontTibialis, rightBackTibialis, leftFrontTibialis, leftBackTibialis);

    }
	// Skriv t.ex rightBackChest.MoveMuscle(1000, true) om du vill kontrahera rightBackChest med kraft 1000.
    // Om det istället hade stått leftBackGluteus.MoveMuscle(2000, false) hade leftBackGluteus sträckts ut med kraft 2000.
    // Använd bara positiva krafter, om du vill ha en negativ kraft, använd den motsatta boolean.
	void Update () {
		
        balance();
    }
    // Ett försök att balansera. Den funkar bättre desto tyngre fötterna är.
    private void balance()
    {
        float bodyAngle = body.transform.rotation.eulerAngles.x;
        bool angleBool = !(bodyAngle < 340 && bodyAngle > 270);
        float forwardZ = (rightFrontFoot.transform.position.z + leftFrontFoot.transform.position.z) / 2;
        float backZ = (rightBackFoot.transform.position.z + leftBackFoot.transform.position.z) / 2;
        float z = body.transform.position.z;
        if (z - .6 < backZ)
        {
            gluteus.MoveFront(t, angleBool);
            gluteus.MoveBack(t, true);
            tibialis.MoveAll(t, true);

        }
        else if (z + .6 > forwardZ)
        {
            chest.MoveAll(t, true);
            gastro.MoveAll(t, true);
        }
        hamstring.MoveAll(5000, false);
    }
}

public class Muscle{
    private Rigidbody upper, lower;
    public Muscle(Rigidbody upper, Rigidbody lower)
    {
        this.upper = upper;
        this.lower = lower;
    }
    public void MoveMuscle(float force, bool contract)
    {
        force = Mathf.Abs(force);
        if (contract)
        {
            force = -force;
        }
        Vector3 direction1 = upper.transform.position - lower.transform.position;
        direction1.Normalize();
        direction1 = direction1 * force;
        Vector3 direction2 = -direction1;
        upper.AddForce(direction1 * Time.deltaTime);
        lower.AddForce(direction2 * Time.deltaTime);
    }
}

public class MuscleGroup
{
    private Muscle frontRight, backRight, frontLeft, backLeft;
    public MuscleGroup(Muscle frontRight, Muscle backRight, Muscle frontLeft, Muscle backLeft)
    {
        this.frontRight = frontRight;
        this.backRight = backRight;
        this.frontLeft = frontLeft;
        this.backLeft = backLeft;
    }
    public void MoveAll(float force, bool contract)
    {
        frontRight.MoveMuscle(force, contract);
        backRight.MoveMuscle(force, contract);
        frontLeft.MoveMuscle(force, contract);
        backLeft.MoveMuscle(force, contract);
    }
    public void MoveFront(float force, bool contract)
    {
        frontRight.MoveMuscle(force, contract);
        frontLeft.MoveMuscle(force, contract);
    }
    public void MoveBack(float force, bool contract)
    {
        backRight.MoveMuscle(force, contract);
        backLeft.MoveMuscle(force, contract);
    }
    public void MoveRight(float force, bool contract)
    {
        frontRight.MoveMuscle(force, contract);
        backRight.MoveMuscle(force, contract);
    }
    public void MoveLeft(float force, bool contract)
    {
        frontLeft.MoveMuscle(force, contract);
        backLeft.MoveMuscle(force, contract);
    }
}
*/
