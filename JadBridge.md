Denne fil l�ses bedst i en MarkDown viewer!
 - fx.: Extension i VS: MarkDown editor af Mads Kristensen.
 - 


****Getting started****

  - todo:
    - move (this solution) away from GitHub (because of keys)
    - 

**Questions**
* Database or no database?
  * kan uuid blot ligge i cachen?
  * som indl�ses fra en fil / f�et via ftp.


**Tasks**

 * Create "lookup" strategy (for looking up in cache)
   * Fx: prefix?
 * Deceide for Redis: StackExchange or simple.
  * how should keys look like? 
	"To from xml to UUDI"	
		Fx. "SagSagTypeSag", "Sag:Sag:Type:Sag"
		BasisObjekt Objekt Type-Rolle V�rdi 
		Sag Sag Type  Sag 

	"From UUID to xml"

		then we can just use the UUID.


 * Create system for loading / refreshing cache
 * 


**Testing**
* Mock objects?
* Create SUT object??
* Guidelines?
* Skal vi ikke bruge Microsoft.Extensions.DependencyInjection

*Sp�rgsm�l til Adam / Logic*
 * new xxx i Test? Well, det er vist ok!
 * Bruger de: Microsoft.Extensions.DependencyInjection


**Naming conventions - unittets**

* https://enterprisecraftsmanship.com/posts/you-naming-tests-wrong/
* [MethodUnderTest]\_[Scenario]\_[ExpectedResult]
* 



Markdown syntax:
__bold__
_italics_

