using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulacroScript : MonoBehaviour
{
    // Start is called before the first frame update

    #region Variables
    public int suscritosJuveniles = 10;
    public int suscritosAdultos = 20;

    private int _juvenileProfs;
    private int _adultProfs;
    private int _juvCoordinators;
    private int _adultCoordinators;

    private readonly int _profPerJuvenile = 10;
    private readonly int _profPerAdult = 20;
    private readonly int _coordinatorPerProf = 5;

    private readonly int _maxProfessors = 100;
    private readonly int _minProfessors = 0;


    private int[] waitingInLine;
     
    #endregion
    
    public int CalculateProfessors(int amountPerPerson, int value)
    {
        return value / amountPerPerson;
    }

    public int CalculateCoordinators(int professors)
    {
        int remainder = professors % _coordinatorPerProf;
        int calculated = professors / _coordinatorPerProf;

        if (remainder == 0)
        {
            return calculated;
        }

        return calculated + 1;
    }

    public int[] CalculatePeopleWaiting(int juveniles, int adults, int juvenileProfs, int adultProfs)
    {
        int waitingJuvs = juveniles % juvenileProfs;
        int waitingAdults = adults % adultProfs;
        return new int[] { waitingJuvs, waitingAdults };
    }

    public bool ValidateData()
    {
        if (suscritosAdultos > _maxProfessors || suscritosJuveniles > _maxProfessors)
        {
            Debug.Log("Solo puede haber 100 de cada categoria");
            return false;
        }

        if (suscritosJuveniles < _minProfessors || suscritosJuveniles < _minProfessors)
        {
            Debug.Log("Ingresa una cantidad valida, mayor o igual a 0.");
            return false;
        }
        return true;
    }

    void Start()
    {   
        if (!ValidateData())
        {
            return;
        }

        _juvenileProfs = CalculateProfessors(_profPerJuvenile, suscritosJuveniles);
        _adultProfs = CalculateProfessors(_profPerAdult, suscritosAdultos);

        _juvCoordinators = CalculateCoordinators(_juvenileProfs);
        _adultCoordinators = CalculateCoordinators(_adultCoordinators);

        waitingInLine = CalculatePeopleWaiting(suscritosJuveniles, suscritosAdultos, _juvenileProfs, _adultProfs);

        Debug.Log("Se necesitan: " + _juvenileProfs + "para los juveniles");
        Debug.Log("Se necesitan: " + _adultProfs + "para los adultos");

        Debug.Log("Se necesitan: " + _juvCoordinators + "para los juveniles");
        Debug.Log("Se necesitan: " + _adultCoordinators + "para los adultos");

    }
}
