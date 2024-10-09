![UCU](https://github.com/ucudal/PII_Conceptos_De_POO/raw/master/Assets/logo-ucu.png)

# Proyecto 2021 - Segundo Semestre - Segunda Entrega
### FIT - Universidad Católica del Uruguay

<br>

En esta segunda instancia nos enfocaremos en la lógica interna del bot —en el _core_—. Para esto dejaremos por un momento de lado las integraciones con las plataformas de chat.

El siguiente diagrama ilustra lo que denominamos _core_, y los elementos que no son parte de él.

![Core](../Assets/Core.png)

Los siguientes elementos **_no_** son parte del _core_:

- **_Message Gateway_**: componentes relacionados a manejar la entrada y salida de mensajes con los usuarios

- **_Importers_**: componentes relacionados a manejar la importación de datos desde archivos por ejemplo

- **_External Services_**: componentes que representan servicios externos no conversacionales como APIs de Google, etc.

El objetivo de esta entrega será hacer funcionar el _core_ del bot y probar que cumple con la especificación mediante casos de prueba.

## Entregables

- **Proyecto de C#** que incluye:

    - código de la solución (`src/Library/`)

    - casos de pruebas (en uno o mas proyectos de test en carpetas dentro de `test/`)

    - documentación (generada con [Doxygen](https://www.doxygen.nl/index.html)) en el directorio `docs/`

**_Aclaración_**: No es necesario entregar un archivo `Program.cs` con código funcional. El funcionamiento del bot debe quedar evidenciado mediante el proyecto de prueba.

:warning: **_Importante_**: Deben existir casos de prueba para todas las [historias de usuario](../README.md#La-propuesta).

:warning: **_Importante_**: Cada equipo designará qué integrante del equipo desarrollará cada clase. La distribución debe contemplar número de clases y responsabilidades. Se evaluará que cada integrante trabaje en una rama independiente y que se integren los cambios mediante pull requests.

**_Recuerda_**: Haremos especial hincapié en las justificaciones de principios y patrones utilizados, que deberán incluir en comentarios XML en el código.

**_Recuerda_**: Existe un catálogo de patrones de diseño que es parte de la bibliografía del curso. Si no puedes acceder al libro, existen recursos online como [refactoring.guru/design-patterns](https://refactoring.guru/design-patterns). Es importante que conozcas los patrones del catálogo y los utilices en tu solución.

:warning: **_Importante_**: Existe una plantilla de proyecto que tiene configuradas las herramientas de _build_, _test_, _docs_, etc. disponible en [GitHub](https://github.com/ucudal/PII_ProjectTemplate).

## Fecha de entrega

Véase [Tabla de Entregas](../README.md#roadmap-y-entregables).

## Medio de entrega

Se entregará en una [tarea de WebAsignatura](https://webasignatura.ucu.edu.uy/course/view.php?id=288&section=1) un link al repositorio del equipo conteniendo todos los artefactos entregables. Si no se entrega link a un commit específico de la rama _master_ o _main_, el equipo docente evaluará el último commit en _master_ o _main_ previo a la fecha de entrega.

Un integrante por equipo deberá completar la entrega.

**No se admitirán entregas fuera de fecha.**

**Sólo se admitirán entregas por WebAsignatura en la tarea provista con link a GitHub y en la rama master o main<sup>1</sup>.**

Todos los entregables que sean de documentación (diagramas, tarjetas, documentos, etc.) deberán entregarse dentro del directorio `docs/`.

Los proyectos de código fuente deberán crearse dentro del directorio `src/` (como es habitual).

Deberá existir ademas un archivo README.md en la raiz del repositorio para incluír las notas del equipo. Véase [Notas](#notas).

## Notas

Alentamos al equipo a que utilice el archivo de README.md en su repositorio para incluir notas de reflexión durante el desarrollo del proyecto. Estas notas pueden incluír:

- Qué desafíos de la entrega fueron los más difíciles

- Qué cosas aprendieron enfrentándose al proyecto que no aprendieron en clase como parte de la currícula

- Qué recursos (páginas web, libros, foros, etc) encontraron que les fueron valiosos para sortear los desafíos que encontraron

- Y cualquier otro tipo de reflexión, material o comentarios sobre el trabajo en el proyecto.

****

<sup>1</sup> _En caso de que WebAsignatura o GitHub no se encuentren en línea para realizar la entrega antes de finalizado el plazo de entrega se aceptará como excepción entrega por correo electrónico del repositorio completo en formato zip_.

