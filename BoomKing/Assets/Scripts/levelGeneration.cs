using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGeneration : MonoBehaviour
{
    public GameObject simplePlatformMedium;
    public GameObject checkMark;
    public GameObject wall; //vertical borders of the level
    public GameObject horizontalBorder;
    public int levelSize; //la taille du niveau est mesurée en nombre de camera unique, exemple: 2, la taille du niveau est 2 cameras superposées
    private Vector3 referencePosition;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        referencePosition = transform.position; //position de la camera, puisque l'on met ce script sur la camera

        checkMark = Instantiate(checkMark, new Vector2(referencePosition.x, referencePosition.y+(height*levelSize)+1-height), Quaternion.identity); //generation du checkmark, qui sert de limite de hauteur
        GameObject upperBound = Instantiate(horizontalBorder, new Vector2(checkMark.transform.position.x, checkMark.transform.position.y+3), Quaternion.identity); //le plafond du niveau
        GameObject ground = Instantiate(horizontalBorder, new Vector2(referencePosition.x, referencePosition.y-height/2), Quaternion.identity); //le ground
        
        GameObject wallLeft = Instantiate(wall, new Vector2(referencePosition.x-width/2, (referencePosition.y + (height * levelSize) + 1 - height)/2 -1), Quaternion.identity); //mur de gauche
        GameObject wallRight = Instantiate(wall, new Vector2(referencePosition.x+width/2, (referencePosition.y + (height * levelSize) + 1 - height) / 2 - 1), Quaternion.identity); //mur de droite
        wallRight.transform.Rotate(new Vector3(0, 0, -180.0f));
        wallLeft.GetComponent<SpriteRenderer>().size = new Vector2(1, upperBound.transform.position.y - ground.transform.position.y); //on scale les murs pour qu'ils fassent la taille du niveau
        wallRight.GetComponent<SpriteRenderer>().size = new Vector2(1, upperBound.transform.position.y - ground.transform.position.y); //on scale le sprite et pas l'objet pour que la texture puisse se repeter
        wallLeft.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        wallRight.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;



        float bufferPositionY = referencePosition.y - UnityEngine.Random.Range(-5.0f, 2.0f);
        float bufferPositionX = referencePosition.x;
        for (int i=0; i<levelSize*2; i++) //creation des platformes
            //la limite *2 est temporaire
        {
            /*
            //Generation la plus simple
            Instantiate(simplePlatformMedium, new Vector2(referencePosition.x, bufferPositionY), Quaternion.identity); 
            bufferPositionY += height;
            */

            //Generation aleatoire basique
            if (bufferPositionY != checkMark.transform.position.y) //on ne veut pas qu'une plateforme puisse spawn sur le drapeau de fin
            {
                Instantiate(simplePlatformMedium, new Vector2(bufferPositionX, bufferPositionY), Quaternion.identity);
            }
            bufferPositionY += height - UnityEngine.Random.Range(-2.0f, 10.0f); //randomize la hauteur
            bufferPositionX =  referencePosition.x - UnityEngine.Random.Range(-9.0f, 9.0f); //randomize la position horizontale
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
