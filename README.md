
# IAV - Fantasmitos al poder

# IAV - Documento de Producción del Proyecto Final

<br>

## Autor
- Muxu Rubia Luque ([RubiaLuque](https://github.com/RubiaLuque))
<br>

## Propuesta

Este se trata del proyecto final de la asignatura de Inteligencia Artificial para Videojuegos del Grado en Desarrollo de Videojuegos en la UCM. 

Este proyecto consiste en la creación de un prototipo de IA que se basa en la creación de una máquina de estados dirigida por datos. Para ello, se ha creado un entorno 3D con dos niveles que cada uno cuenta con un personaje que controla el jugador y varios fantasmas que vagan por un pueblo. El objetivo es conseguir sacar a todos los fantasmas del pueblo y llevarlos a un cíerculo mágico que hay a las afueras de la entrada. Para hacer esto hay que aprovecharse del comportamiento de los fantasmas. De esta manera hay dos tipos de ellos:

- <b>Tipo I (Extrovertidos)</b>: merodean mientras no vean al jugador, al avistarlo lo persiguen.

- <b>Tipo II (Introvertidos)</b>: al igual que los anteriores, merodean mientras no vean al jugador, pero al verlo huyen y se esconden en un punto aleatorio del pueblo. Permanecen ahí hasta que el jugador los encuentra y los toca, es entonces cuando le empiezan a perseguir. 

Los niveles 1 y 2 se diferencian en el número de fantasmas y la extensión del mapa, así como el número de escondites.

<br>

## Punto de partida
Se parte de un proyecto base de **Unity 2022.3.5f1** vacío al que se le han añadido los diferentes assets que se van a usar para los fantasmas o el entorno, así como la clase ```Merodeo``` de la Práctica 1. Por lo demás, todo se ha hecho desde cero. La práctica constará en la creación de una máquina de estados finita dirigida por datos de manera que actúe como base para crear diferentes máquinas de estados funcionales, en este caso, 2. Es decir, desde la misma FSM base poder crear dos (o incluso más) máquinas que funcionen independientemente, pero que compartan la misma base. Siendo esta misma base la parte funcional y de "motor". Por sí sola, la FSM base no ejecuta ningún estado o acción específico, siendo que estos se le pasan como datos.

Aunque no estaban implementadas antes de empezar el proyecto se puede considerar que la base de la práctica son los scripts de la máquina de estados finita dirigida por datos:

- ```BaseStateMachine```: clase ejecutora de la máquina de estados que lleva cada agente que vaya a hacer uso de la misma.
- ```BaseState```: define el estado base.
- ```State```: define un estado abstracto.
- ```Action```: define una acción que se lleva a cabo mientras se está en un estado. 
- ```Decision```: define una decisión que debe cumplirse para cambiar de estado.
- ```Transition```: se encarga de llevar a cabo los cambios en los estados en base a si se cumple o no la condición de la decisión.

Menos ```BaseStateMachine```, todas las demás clases heredan de ScriptableObjects para así poder hacer que la máquina sea dirigida por datos.

<br><br>

## Guía de estilo del código
Para dar cohesión al trabajo, se ha acordado el uso de unas directrices que seguir a la hora de programar el código (que no el pseudocódigo). Estas son:
- El uso de Camel Case para las variables, ya sean privadas o públicas. Un ejemplo de esto sería: ```int varName```.
- El uso de Pascal Case para la declaración y uso de clases. Por ejemplo: ```class MyClass```. Además de para las funciones, ya que sigue el protocolo de C# para Unity. Por ejemplo: ```void MyFunction()```.
  
Todo el código se escribirá en inglés a excepción de los comentarios, que serán en español. En algunas excepciones se ha usado inglés, siguiendo con la estructura y forma del código base. Lo ideal es que todas las funciones vayan acompañadas de un comentario que describa brevemente su código a no ser que su nombre o brevedad sean autoexplicativos.

<br><br>

## Diseño de la solución

La solución está dividida según varias características:

- <b>Característica A: Creación del entorno: Nivel 1 y 2 </b>

Esta característica engloba la creación de dos niveles, cada uno con un mapa y número de fantasmas y escondites distintos. 

Usando la herramienta Terrain de Unity se ha usado para crear los dos mapas. Para la disposición de los árboles, la hierba y las demás decoraciones se ha usando el pincel de dicha herramienta. 

A su vez, se ha usado ```NavMeshSurface``` para la implementación de movimiento con IA. 

<br>

- <b>Característica B: Movimiento de la cámara y el personaje</b>

Esta característica se basa en el movimiento y control del personaje y la cámara. La cámara no se controla de manera explícita sino que esta se mueve junto al jugador, manteniéndolo en el centro en todo momento.

<br>

- <b>Característica C: Movimientos individuales: Persecución, Merodeo y Huida </b>

Esta caraterística abarca la creación de las acciones a realizar durante los estados de la máquina de estados. Aunque aparece antes, los scripts que se mencionan se crearon después de implementar la máquina de estados base porque esta era necesaria y prioritaria.

Tanto la persecución como el merodeo y la huida son acciones de la máquina de estados, por lo que heredan de una clase ```Action``` y son ```ScriptableObjects```. Se usan como comportamientos de los fantasmas durante la ejecución de sus estados.

<br>

<b>Persecución</b>

El fantasma persigue al jugador usando ```NavMeshSurface``` y ```NavMeshAgent``` para seguirlo esquivando obtáculos. Implícitamente se ejecuta el algoritmo A*. 

```
class Follow : Action

    function: Execute(m = BaseStateMachine)
    
        NavMeshAgent agent = GetComponent<NavMeshAgent>()
        SightSensor sight = GetComponent<SightSensor>()

        agent.SetDestination(sight.playerTransform.position)
```

<br>

<b>Merodeo</b>

El fantasma merodea sin rumbo por la malla de navegación.

```
```

<br>

<b>Huida</b>

El fantasma huye del personaje y se dirige hacia un escondite que no esté ocupado por otro fantasma.

```
```

<br>

- <b>Característica D: Sensores de vista y tacto </b>

Esta característica incluye la creación de sensores que usarán los fantasmas en la toma de decisiones para saber si cambiar o no de estado.

El sensor de <b>vista</b> lo usan los fantasmas para saber si el jugador está o no en su rango de visión.

```
class SightSensor : MonoBehaviour

    Transform playerTransform;
    LayerMask layerToIgnore;
    float maxDistance = 100;
    float maxAngle = 60;
    Ray raycast;

    // Start is called before the first frame update
    function: Awake()
    
        playerTransform = GameObject.Find("PLAYER").GetComponent<Transform>()     
    

    public bool ShootRay()
    
        if playerTransform == null 
            return false

        //Se crea un rayo desde la posicion del fantasma hasta el player y se obtiene la direccion y el angulo con
        // su forward
        raycast = new Ray(this.transform.position, playerTransform.position - this.transform.position)

        Vector3 direction = new Vector3(raycast.direction.x, 0,  raycast.direction.z)

        float rotation = Vector3.Angle(direction, this.transform.forward)

        //Si el angulo es mayor que maxAngle no cuenta como que ha visto al jugador
        if rotation > maxAngle 
            return false;

        ifnot Physics.Raycast(raycast, out RaycastHit hit, maxDistance, ~layerToIgnore)
            return false;

        if hit.collider.GetComponent<CharacterMove>() != null 
            return true;

        return false
```

El sensor de <b>tacto</b> se usa para saber si el jugador está tocando o no al propio fantasma.

```
```

<br>

- <b>Característica E: Creación de FMS base dirigida por datos </b>

Esta característica incluye el crear una máquina de estados base abstracta que actúe a modo de "caja negra" y que sea dirigida por datos. Es decir, que se caracterice por su versatilidad y capacidad de crear multitud de diferentes máquinas de estados, todas ellas construidas sobre una base sólida. El hecho de que sea dirigida por datos permite crear acciones, decisiones y transiciones que funcionen independientemente de cómo esté hecha la máquina, ya que esta actúa como motor. 


![IAV](https://github.com/RubiaLuque/IAV24-RubiaLuque/assets/95546683/d8f942a4-b99e-4bd4-b3a1-81762754dcad)


<br>

- <b>Característica F: Creación de acciones, transiciones y decisiones para los fantasmas</b>

Para probar la versatilidad y capacidad de crear varios tipos de máquinas, se han creado dos máquinas distintas; una para cada tipo de fantasma para que cumplan los comportamientos descritos en la Propuesta.
Los fantasmas de Tipo I tienen una máquina de estados más sencilla que se muestra en el diagrama siguiente:

![Selector principal](https://github.com/RubiaLuque/IAV24-RubiaLuque/assets/95546683/1f3caee0-ec2a-419f-9f9c-1734c15b5917)

<br>

Mientras tanto, los fantasmas de Tipo II tienen la máquina de estados descrita por el diagrama inferior:

![Selector principal2](https://github.com/RubiaLuque/IAV24-RubiaLuque/assets/95546683/7245d981-78c8-44a2-a373-bde7dad01178)

<br>
<br>

## Pruebas y métricas


Característica A: Creación del entorno: Nivel 1 y 2
<table>
    <tr>
        <th><b>A.1</b></th>
        <th>Dos niveles funcionales con 10 fantasmas el primero y 25 el segundo.</th>
    </tr>
     <tr>
        <th><b>A.2</b></th>
        <th>Los elementos creados con Terrain son colisionables.</th>
    </tr>
    
</table>
<br>
Característica B: Movimiento de la cámara y el personaje
<table>
    <tr>
        <th><b>B.1</b></th>
        <th>Probar el correcto movimiento con WASD del personaje.</th>
    </tr>
    <tr>
        <th><b>B.2</b></th>
        <th>Probar que cuando el jugador se mueve hacia cualquier dirección, la cámara le sigue, manteniéndolo en el centro.</th>
    </tr>
    
</table>
<br>
Característica C: Movimientos individuales: Persecución, Merodeo y Huida
<table>
    <tr>
        <th><b>C.1</b></th>
        <th>Comprobar que el fantasma es capaz de perseguir al jugador esquivando obstáculos.</th>
    </tr>
    <tr>
        <th><b>C.2</b></th>
        <th>Comprobar que cuando más de 3 fantasmas persiguen al jugador, estos son capaces de organizarse para pasar por la puerta principal o entre obstáculos juntos entre sí.</th>
    </tr>
    <tr>
        <th><b>C.3</b></th>
        <th>Comprobar que el merodeo es individual.</th>
    </tr>
    <tr>
        <th><b>C.4</b></th>
        <th>Comprobar que al huir, los escondites los ocupa un solo fantasma.</th>
    </tr>
</table>
<br>
Característica D: Sensores de percepción y tacto de los fantasmas
<table>
    <tr>
        <th><b>D.1</b></th>
        <th>Comprobar que los fantasmas ejecutan sus respectivas acciones al estar el jugador en su campo de visión.</th>
    </tr>
    <tr>
        <th><b>D.2</b></th>
        <th>Comprobar que los fantasmas reconocen el toque del jugador con un mensaje por Debug.</th>
    </tr>
</table>
<br>
Característica E: Máquina de estados genérica y creación desde el Editor de Unity
<table>
    <tr>
        <th><b>E.1</b></th>
        <th>Comprobación de etiquetas de creación de acciones, transiciones y estados desde el Menú de Unity.</th>
    </tr>
    <tr>
        <th><b>E.2</b></th>
        <th>Comprobación de creación de una máquina de estado específica desde el Editor de Unity.</th>
    </tr>
</table>
<br>
Característica F: Máquinas de estados específicas de los fantasmas: paso entre estados y correcto funcionamiento de las acciones y decisiones
<table>
    <tr>
        <th><b>F.1</b></th>
        <th>En la máquina de estados 1 comprobar si se pasa de Merodear a Seguir al jugador al verlo..</th>
    </tr>
  <tr>
        <th><b>F.2</b></th>
        <th>En la máquina de estados 2 comprobar si se pasa de Merodear a Huir del jugador al verlo.</th>
    </tr>
  <tr>
        <th><b>F.3</b></th>
        <th>En la máquina de estados 2 comprobar si, al ser tocados por el jugador, estos le siguen.</th>
    </tr>
  <tr>
        <th><b>F.4</b></th>
        <th>Comprobar que los fantasmas que huyen se detienen al llegar a un escondite y se quedan quietos.</th>
    </tr>
</table>
<br>

<br>



## Producción


| Estado  |  Tarea  |  Fecha  |  
|:-:|:--|:-:|
| ✔️ | Diseño: Documentación inicial | 16-05-2024 |
| ✔️ | Característica A: Creación del entorno: Nivel 1 y 2 | 27-05-2024 |
| ✔️ | Característica B: Movimiento de la cámara y el personaje | 23-06-2024 |
| :x: | Característica C: Movimientos individuales: Persecución, Merodeo y Huida | - |
| ✔️ | Característica D: Sensores de vista y tacto | 18-06-2024 |
| ✔️ | Característica E: Creación de FMS base dirigida por datos | 17-06-2024 |
| :x: | Característica F: Creación de acciones, transiciones y decisiones para los fantasmas | - |
| :x: | Diseño: Documentación final | - |
| :x: | Vídeo | - |




<br><br>

## Referencias

- [Tadevosyan G., Unity AI Development: A Finite-state Machine Tutorial, Toptal](https://www.toptal.com/unity-unity3d/unity-ai-development-finite-state-machine-tutorial)
- [ScriptableObject, Unity Manual](https://docs.unity3d.com/Manual/class-ScriptableObject.html)
- [Unite Austin 2017 - Game Architecture with Scriptable Objects, Unity, YouTube video](https://www.youtube.com/watch?v=raQ3iHhE_Kk)
- [fsm-unity-article, GitHub repository](https://github.com/itsdikey/fsm-unity-article/tree/inital)
- [Little Ghost lowpoly(FREE), SR Studios Kerala](https://assetstore.unity.com/packages/3d/characters/little-ghost-lowpoly-free-271926)
- [FREE - Modular Character - Fantasy RPG Human Male](https://assetstore.unity.com/packages/3d/characters/humanoids/humans/free-modular-character-fantasy-rpg-human-male-228952)


