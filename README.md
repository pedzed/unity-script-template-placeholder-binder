# Script template placeholder binder

When you want to create a new script in Unity3D, you will notice that pre-existing code is already generated for you.
This code is called a template. In a default Unity (64-bit) Windows installation, the templates are located in
`C:\Program Files\Unity\Editor\Data\Resources\ScriptTemplates`. You can modify them there as you wish.

Let's take `81-C# Script-NewBehaviourScript.cs.txt` as an example. It should contain something similar to the following:

```cs
using UnityEngine;
using System.Collections;

public class #SCRIPTNAME# : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        
    }
    
    // Updated is called once per frame
    void Update () {
        
    }
    
}
```

By using this Unity Editor extension, you will get an extra set of placeholders (or "variables") to use for your 
script templates.


## Usage

1. Download the [Unity Package](https://github.com/pedzed/unity-script-template-placeholder-binder/raw/master/ScriptTemplatePlaceholderBinder.unitypackage).
2. Import the Unity Package to your project.
3. Modify the template files as you wish using the available placeholders.


## Example templates
File `81-C# Script-NewBehaviourScript.cs.txt`:

```cs
using UnityEngine;
using System.Collections;

namespace #PASCALCASED_COMPANY_NAME#.#PASCALCASED_PROJECT_NAME#
{
    public class #PASCALCASED_SCRIPT_NAME# : MonoBehaviour
    {
        private void Start()
        {
            //
        }
        
        private void Update()
        {
            //
        }
    }
}

```


## Available placeholders

| Placeholder                  | Description                                                             |
|------------------------------|-------------------------------------------------------------------------|
| `#PASCALCASED_COMPANY_NAME#` | Gets the company name in PascalCase                                     |
| `#PASCALCASED_PROJECT_NAME#` | Gets the project name in PascalCase                                     |
| `#PASCALCASED_SCRIPT_NAME#`  | Gets the script name in PascalCase.                                     |
| `#CREATION_DATE#`            | Gets the script's creation date.                                        |

### Company name
The company name placeholder makes use of 
[`PlayerSettings.companyName`](https://docs.unity3d.com/ScriptReference/PlayerSettings-companyName.html).
It can be changed by going to `Edit > Project Settings > Player`.

### Project name
The project name placeholder makes use of 
[`PlayerSettings.productName`](https://docs.unity3d.com/ScriptReference/PlayerSettings-productName.html).
It can be changed by going to `Edit > Project Settings > Player`.
