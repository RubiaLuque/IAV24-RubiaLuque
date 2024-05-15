
# IAV - Fantasmicos al poder

# IAV - Documento de Producción del Proyecto Final

<br>

> [!CAUTION]
> La licencia sobre la herramienta Behaviour Designer 1.7.9 incluída en este repositorio no es de uso libre. Se recomienda no usar sin disponer de una licencia válida. Se encuentra aquí disponible debido a que no se ha podido retirar para el correcto funcionamiento de la versión final del proyecto. No me hago cargo de las responsabilidades legales que puedan recaer sobre quien haga uso de estas herramientas sin autorización previa del propietario original. El uso de esta herramienta en este repositorio tiene únicamente la finalidad de aportar académicamente a un trabajo universitario sin ánimo de lucro ni difusión.

<br>

## Autor
- Muxu Rubia Luque ([RubiaLuque](https://github.com/RubiaLuque))
<br>

## Propuesta

Este se trata del proyecto final de la asignatura de Inteligencia Artificial para Videojuegos del Grado en Desarrollo de Videojuegos en la UCM. 

Este proyecto consiste en la creación de un prototipo de IA que se basa en el movimiento en grupo y persecución al jugador. El juego se desarrolla en un mundo en 3D y tiene un sistema basado en juegos roguelike de acción. Consta de dos mapas con puntos de spawn en los que se suceden oleadas de enemigos que el protagonista debe abatir antes de poder pasar de mapa o nivel y así salir de la mazmorra en la que está encerrado. La IA irá guiando a cada grupo de enemigos, formado de 3 a 10 fanasmas, hacia el jugador para atacarle. Estos fantasmas están encabezados por un líder que determina la marcha. El objetivo es mantener la formación durante el trayecto mientras se esquivan obstáculos o se pasan por pasillos estrechos. Se requiere de adaptabilidad y flexibilidad para acercarse al jugador, desaciendo las posiciones cuando se requiera y volviendo a recomponerse después. Habrá diferentes tipos de formaciones grupales de enemigos.

<br>

## Punto de partida
Se parte de un proyecto base de **Unity 2022.3.5f1** con la herramienta Behaviour Designer añadida en la carpeta assets al cual se le añaden otros assets gratuitos para crear los escenarios, enemigos y personaje (ver Referencias para más detalle). Se usarán los Behaviour Trees de la herramienta mentada anteriormente para el comportamiento del grupo y de cada individuo.

Las clases bases que se usarán son:
- ```PlayerController```: control del proyagonista con WASD.
- ```ClusterBehaviour```: comportamiento de la formación de los enemigos.
- ```ClusterManager```: se encarga de los distintos tipos de formaciones y su composición.
- ```SpawnManager```: control del tiempo entre grupos de enemigos y su numero por cada punto de spawn.
- ```ClusterLeader```: clase que debe tener el lider de cada grupo, encabeza la marcha y se comunica con el resto de integrantes.
- ```CameraController```: control del movimiento de la cámara para que siga al personaje.

A su vez, se usarán las clases de Behaiour Designer, en específico aquellas que se encuentran en la subcarpeta Tasks de Formations:
- ```Circle```: forma de círculo o circunferencia.
- ```Diamond```: forma de diamante o rombo.
- ```Wedge```: forma en V con el líder al frente.
- ```Row``` y ```Line```: forma de línea horizontal o varias líneas horizontales, respectivamente.
- ```Triangle```: forma de triángulo con todas las posiciones interiores cubiertas.
- ```Formation Agent```: tiene referencias y variables para cada elemento (enemigo, en este caso) que se encuentra en la formación.
- ```Formation Group```: comportamiento del grupo dentro del movimiento y formación: escucha de órdenes, seguimiento del objetivo, mantenimiento de la formación, esquiva de obstáculos...

También se hará uso de las clases de Movement:
- ```Group Movement```: movimiento del grupo.
- ```Movment```: algoritmo A* o de seguimiento elegido.

Por último, se usarán las tácticas de combate definidas en Tactics:
- ```Charge```: cargar hasta el objetivo y atacar al alcanzarlo.
- ```Flank```: flanequear al objetivo desde alguno de sus laterales.
- ```Surround```: rodear al objetivo.
- ```Tactical Agent```: tiene referencias y variables para cada elemento (enemigo, en este caso) que se encuentra en la formación que va a realizar las tácticas de combate anteriores.
- ```Tactical Group```: comportamiento del grupo dentro del combate: definición del líder, qué comportamiento seguir según el árbol de comportamiento de dicho lider, objetivo al que atacar...

<br><br>
## Guía de estilo del código
Para dar cohesión al trabajo, se ha acordado el uso de unas directrices que seguir a la hora de programar el código (que no el pseudocódigo). Estas son:
- El uso de Camel Case para las variables, ya sean privadas o públicas. Un ejemplo de esto sería: ```int varName```.
- El uso de Pascal Case para la declaración y uso de clases. Por ejemplo: ```class MyClass```. Además de para las funciones, ya que sigue el protocolo de C# para Unity. Por ejemplo: ```void MyFunction()```.
  
Todo el código se escribirá en inglés a excepción de los comentarios, que serán en español. En algunas excepciones se ha usado inglés, siguiendo con la estructura y forma del código base. Lo ideal es que todas las funciones vayan acompañadas de un comentario que describa brevemente su código a no ser que su nombre o brevedad sean autoexplicativos.

<br><br>
## Diseño de la solución

Se trata de un algoritmo iterativo en el que en cada iteración se exploran las conexiones del nodo actual y en los registros de sus nodos hijos se guarda en coste hasta el momento. Hasta aquí es como usar Dijkstra, pero la diferencia entre ambos algoritmos radica en que A* al coste real se le suma la estimación de la función heurística y se guarda el resultado: la estimación del coste total del mejor camino origen-destino que pasa por ese nodo.

Se usará en los enemigos y se le dará unicamente al líder de cada grupo que encabezará la marcha. El resto de integrantes se deberán de posicionar con respecto a dicho líder. De esta manera, se aumenta la eficacia del código y se compartimentaliza la funcionalidad.

```
function pathfindStar(graph: Graph. start: Node, end: Node, heuristic: Heuristic) -> Connection[]:

    # Se usa esta estructura para guardar la información de cada nodo y llevar un registro
    class NodeRecord:
        node: Node
        connection: Connection
        costSoFar: float
        estimatedTotalCost: float
    
    # Se inicializa para el primer nodo
    startRecord = new NodeRecord()
    startRecord.node = start
    startRecord.connection = null
    startRecord.costSoFar = 0
    startRecord.estimatedTotalCost = heuristic.estimate(start)

    # Se inicializan las listas abierta y cerrada
    open = new PathfindingList()
    open += startRecord
    closed = new PathfindingList()

    # Se itera en el procesamiento de cada nodo
    while length(open) > 0
        # Se busca el menor elemento de la lista abierta usando el coste estimado total
        current = open.smallestElement()

        # Si es el nodo buscado se termina el bucle
        if current.node == goal:
            break

        # Si no, se continúa con las conexiones salientes del nodo
        connections = graph.getConnections(current)

        # Se recorre cada conexión
        for connection in connections:
            # Se obtiene el coste estimado del último nodo
            endNode = connection.getToNode()
            endNodeCost = current.costSoFar + connection.getCost()

            # Si el nodo está cerrado es posible que se tenga que eliminar de la lista cerrada
            # o saltarlo
            if closed.contains(endNode):
                # Se encuentra aqui los elementos guardados en la lista cerrada correspondientes
                # a endNode
                endNodeRecord = closed.find(endNode)
                
                # Si no hemos encontrado una ruta más corta, se salta
                if endNodeRecord.constSoFar <= endNodeCost:
                    continue
                
                # A diferencia de Dijkstra, aqui sí se puede encontrar un camino más barato que el que se tenía

                # En otro caso, se elimina de la lista cerrada
                closed -= endNodeRecord

                # Se puede usar los antiguos valores del coste del nodo para calcular su 
                # heurística sin tener que llamar a la funcion heurística, que puede consumir bastantes recursos
                endNodeHeuristic = endNodeRecord.estimatedTotalCost - endNodeRecord.costSoFar

            # Se salta si el nodo esta abierto y no hemos encontrado una ruta mejor
            else if open.contains(endNode):
                # Aquí se encuentra la lista de nodos abiertos correspondiente a endNode
                endNodeRecord = open.find(endNode)

                # Si la ruta no es mejor, se salta
                if endNodeRecord.costSoFar <= endNodeCost:
                    continue
                
                #De nuevo, se calcula su heurística
                endNodeHeuristic = endNodeRecord.cost - endNodeRecord.costSoFar
            
            # De otra forma se sabe que hemos topado con un nodo no visitado, así que se guarda
            else:
                endNodeRecord = new NodeRecord()
                endNodeRecord.node = endNode

                # Se necesita calcular el valor heurístico usando la función, ya 
                # que no tenemos datos guardados sobre los que apoyarnos
                endNodeHeuristic = heuristic.estimate(endNode)
            
            # Se actualiza el coste, estimación y conexiones del nodo
            endNodeRecord.cost = endNodeCost
            endNodeRecord.connection = connection
            endNodeRecord.estimatedTotalCost = endNodeCost + endNodeHeuristic

            # Se añade a la lista de nodos abiertos
            if not open.contains(endNode):
                open += endNodeRecord
        
        # Se ha acabado de revisar las conexiones del nodo actual, así que
        # se añade a la lista cerrada y se elimina de la abierta
        open -= current
        closed += current

    # Se ha encontrado el nodo objetivo o si no hay más nodos que buscar
    if current.node != goal:
        # No hay más nodos y no hemos alcanzado el objetivo, así que no hay solución
        return null

    else:
        # Se crea la lista de conexiones en el path
        path = []
        # Se recorre hacia atrás el path, acumulando conexiones
        while current.node != start:
            path += current.connection
            current = current.connection.getFromNode()

        # Se le da la vuelta al path y se devuelve
        return reverse(path)
```

<br>

Se ha hablado de heurística, así que a continuación se muestra el pseudocódigo para dicha clase y su funcionalidad. Se trata de una clase que se encarga de la estimación de los costes de recorrer las aristas de un grafo y pasar por sus nodos dado un nodo inicial:
```
class Heuristic:
    # Se almacena el nodo al que se quiere llegar y que esta heurística está estimando
    goalNode: Node

    function estimate(node: Node) -> float

    # Coste estimado para alcanzar el nodo almacenado como meta para el nodo inicialmente dado
    function estimate(fromNode: Node) -> float:
        return estimate(fromNode, goalNode)

    # Coste estimado para moverse entre dos nodos
    function estimate(fromNode: Node, toNode: Node) -> float
```

Para el compoortamiento del resto de integrantes del grupo se usarán los Behaviour Trees de la herramienta Behaviour Designer, en específico los scripts de la carpeta Behaviour Designer Formations.
El comportamiento de los enemigos se desarrolla seguiendo el siguiente árbol de decisión:



<br>

## Pruebas y métricas


Característica A: Movimiento del personaje y cámara
<table>
    <tr>
        <th><b>A.1</b></th>
        <th>Probar el movimiento correcto con WASD del protagonista.</th>
    </tr>
     <tr>
        <th><b>A.2</b></th>
        <th>Probar que cuando el jugador se mueve hacia cualquier dirección, la cámara le sigue, manteniéndolo en el centro.</th>
    </tr>
    
</table>
<br>
Característica B: Creación de los dos niveles
<table>
    <tr>
        <th><b>B.1</b></th>
        <th>Comprobar que hay un intervalo de 7 segundos entre cada grupo instanciado del nivel 1.</th>
    </tr>
    <tr>
        <th><b>B.2</b></th>
        <th>Comprobar que hay un intervalo de 5 segundos entre cada grupo instanciado del nivel 2.</th>
    </tr>
    <tr>
        <th><b>B.3</b></th>
        <th>Comprobar la colisión del jugador contra todos los elementos del entorno de cada nivel.</th>
    </tr>
    
</table>
<br>
Característica C: Ciclo de juego
<table>
    <tr>
        <th><b>C.1</b></th>
        <th>Comrpobar que se pasa correctamente del nivel 1 al 2 al derrotar a todos los enemigos del 1.</th>
    </tr>
    <tr>
        <th><b>C.2</b></th>
        <th>Comprobar que se acaba el juego y se vuelve al menú cuando se acaba con todos los enemigos del nivel 2.</th>
    </tr>
</table>
<br>
Característica D: Persecución con A*
<table>
    <tr>
        <th><b>D.1</b></th>
        <th>Comprobar que el lider de la formación puede trazar un camino óptimo hacia el jugador esquivando obstáculos.</th>
    </tr>
</table>
<br>
Característica E: Movmiento el grupo
<table>
    <tr>
        <th><b>E.1</b></th>
        <th>Probar que la formación puede adaptarse a pasillos estrechos del nivel 2.</th>
    </tr>
  <tr>
        <th><b>E.2</b></th>
        <th>Probar que la formación puede rodear los obtáculos del nivel 1: Separación y reagrupación, cambio de la formación según el entorno.</th>
    </tr>
  <tr>
        <th><b>E.3</b></th>
        <th>Probar que hay una formación que avanza en línea horizontal.</th>
    </tr>
  <tr>
        <th><b>E.4</b></th>
        <th>Probar que hay una formación en forma de diamante.</th>
    </tr>
  <tr>
        <th><b>E.4</b></th>
        <th>Probar que hay una formación en V.</th>
    </tr>
  <tr>
        <th><b>E.5</b></th>
        <th>Probar que hay una formación en círculo.</th>
    </tr>
  <tr>
        <th><b>E.5</b></th>
        <th>Probar que hay una formación en triángulo.</th>
    </tr>
</table>
<br>

<br>



## Producción


| Estado  |  Tarea  |  Fecha  |  
|:-:|:--|:-:|
| :x: | Diseño: Documentación inicial | 16-05-2024 |
| :x: | Característica A: Movimiento del personaje y cámara | 28-05-2024 |
| :x: | Característica B: Creación de los dos niveles | 28-05-2024 |
| :x: | Característica C: Ciclo de juego | 28-05-2024 |
| :x: | Característica D: Persecución con A* | 28-05-2024 |
| :x: | Característica E: Movimiento en grupo | 28-05-2024 |
| :x: | Diseño: Documentación final | 28-05-2024 |
| :x: | Vídeo | 28-05-2024 |




<br><br>

## Referencias

- *AI for Games*, Ian Millington.
- [Behaviour Designer 1.7.9, Opsive](https://assetstore.unity.com/packages/tools/visual-scripting/behavior-designer-behavior-trees-for-everyone-15277#description)
- [Ultimate Low Poly Dungeon, Broken Vector](https://assetstore.unity.com/packages/3d/environments/dungeons/ultimate-low-poly-dungeon-143535)
- [Little Ghost lowpoly(FREE), SR Studios Kerala](https://assetstore.unity.com/packages/3d/characters/little-ghost-lowpoly-free-271926)
- [FREE - Modular Character - Fantasy RPG Human Male](https://assetstore.unity.com/packages/3d/characters/humanoids/humans/free-modular-character-fantasy-rpg-human-male-228952)
- [AI-Formations, EezehDev](https://github.com/EezehDev/AI-Formations)
- [Learn To Create Enemy AI With A Few Lines of Code In Unity Game Engine, AwesomeTuts](https://awesometuts.com/blog/unity-enemy-ai/)

