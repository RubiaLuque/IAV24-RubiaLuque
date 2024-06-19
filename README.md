
# IAV - Fantasmitos al poder

# IAV - Documento de Producción del Proyecto Final

<br>

<br>

## Autor
- Muxu Rubia Luque ([RubiaLuque](https://github.com/RubiaLuque))
<br>

## Propuesta

Este se trata del proyecto final de la asignatura de Inteligencia Artificial para Videojuegos del Grado en Desarrollo de Videojuegos en la UCM. 

Este proyecto consiste en la creación de un prototipo de IA que se basa en la creación de una máquina de estados dirigida por datos. Para ello, se ha creado un entorno 3D con dos niveles que cada uno cuenta con un personaje que controla el jugador y varios fantasmas que vagan por un pueblo. El objetivo es conseguir sacar a todos los fantasmas del pueblo y llevarlos a un cíerculo mágico que hay a las afueras de la entrada. Para hacer esto hay que aprovecharse del comportamiento de los fantasmas. De esta manera hay dos tipos de ellos:

- <b>Extrovertidos</b>: merodean mientras no vean al jugador, al avistarlo lo persiguen.

- <b>Introvertidos</b>: al igual que los anteriores, merodean mientras no vean al jugador, pero al verlo huyen y se esconden en un punto aleatorio del pueblo. Permanecen ahí hasta que el jugador los encuentra y los toca, es entonces cuando le empiezan a perseguir. 

Los niveles 1 y 2 se diferencian en el número de fantasmas y la extensión del mapa, así como el número de escondites.

<br>

## Punto de partida
Se parte de un proyecto base de **Unity 2022.3.5f1** vacío al que se le han añadido los diferentes assets que se van a usar para los fantasmas o el entorno, así como la clase ```Merodeo``` de la Práctica 1. Por lo demás, todo se ha hecho desde cero.

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
        <th>Comprobar que, al ser tocados por el jugador, los fantasmas introvertidos lo siguen.</th>
    </tr>
</table>
<br>
Característica E: Máquina de estados genérica y creación desde el Editor de Unity
<table>
    <tr>
        <th><b>E.1</b></th>
        <th>.</th>
    </tr>
</table>
<br>
Característica F: Máquinas de estados específicas de los fantasmas: paso entre estados y correcto funcionamiento de las acciones y decisiones
<table>
    <tr>
        <th><b>F.1</b></th>
        <th>.</th>
    </tr>
  <tr>
        <th><b>F.2</b></th>
        <th>.</th>
    </tr>
  <tr>
        <th><b>F.3</b></th>
        <th>.</th>
    </tr>
  <tr>
        <th><b>F.4</b></th>
        <th>.</th>
    </tr>
  <tr>
        <th><b>E.5</b></th>
        <th>.</th>
    </tr>
  <tr>
        <th><b>E.6</b></th>
        <th>.</th>
    </tr>
  <tr>
        <th><b>E.7</b></th>
        <th>.</th>
    </tr>
  <tr>
        <th><b>E.8</b></th>
        <th>.</th>
    </tr>
  <tr>
        <th><b>E.9</b></th>
        <th>.</th>
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
| :x: | Característica C: Movimientos individuales: Persecución, Merodeo y Huida | 28-05-2024 |
| :x: | Característica D: Sensores de vista y tacto | 28-05-2024 |
| ✔️ | Característica E: Creación de FMS base dirigida por datos | 16-05-2024 |
| :x: | Característica F: Creación de acciones, transiciones y decisiones para los fantasmas | 28-05-2024 |
| :x: | Diseño: Documentación final | 28-05-2024 |
| :x: | Vídeo | 28-05-2024 |




<br><br>

## Referencias

- [Tadevosyan G., Unity AI Development: A Finite-state Machine Tutorial, Toptal](https://www.toptal.com/unity-unity3d/unity-ai-development-finite-state-machine-tutorial)
- [ScriptableObject, Unity Manual](https://docs.unity3d.com/Manual/class-ScriptableObject.html)
- [Unite Austin 2017 - Game Architecture with Scriptable Objects, Unity, YouTube video](https://www.youtube.com/watch?v=raQ3iHhE_Kk)
- [fsm-unity-article, GitHub repository](https://github.com/itsdikey/fsm-unity-article/tree/inital)
- [Little Ghost lowpoly(FREE), SR Studios Kerala](https://assetstore.unity.com/packages/3d/characters/little-ghost-lowpoly-free-271926)
- [FREE - Modular Character - Fantasy RPG Human Male](https://assetstore.unity.com/packages/3d/characters/humanoids/humans/free-modular-character-fantasy-rpg-human-male-228952)


