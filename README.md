# Ividence Programmatic Templates StarterKit

Vous forkerez le repository et en partant des trois PSD contenus dans le dossier [psd/](psd/) et de la [solution](src/Ividence.Programmatic.Templates.StarterKit.sln) fournie, vous réaliserez un et un seul template XAML qui :

- sera absolument **standalone**, c'est à dire qu'il ne dépendra d'aucun autre fichier de resource,
- n'aura pas de taille fixe, mais une DesignWidth et DesignHeith de départ de 300x250, 
- aura comme DataContext le model defini par la class [`Item`](src/Ividence.Programmatic.Renderer.Core/Models/Item.cs)
- n'utilisera uniquement que les converters présents dans le namespace `Ividence.Programmatic.Renderer.Core.Converters`, et en particulier **[`UriToBitmapSourceConverter`](src/Ividence.Programmatic.Renderer.Core/Converters/UriToBitmapSourceConverter.cs)** pour charger les images externes.
- s'adaptera en fonction de la valeur de la property `Item.Kind` et respectera les demandes suivantes :
  * `native`: [Native Template.psd](psd/Native%20Template.psd)
    * binding des properties `Title`, `Description`, `Image.Url`,
    * l'image doit occuper toute la largeur, de hauteur fixe et être centrée verticalement dans son espace disponible (crop en haut et en bas si nécessaire),
    * le logo (L) qui suit Sponsorisé par est disponible [ici](http://img.programatik.email/common/ligatus/logo-dark-grey-transparent-round.png).
    
  * `product`: [Product Template.psd](psd/Product%20Template.psd)
    * binding des properties `Description`, `Price.Value`, `Price.ShippingCost`, `Price.Currency`, `Image.Url`, `Merchant.LogoUrl`,
    * l'image ne doit ni être déformée, ni être croppée,
    * le prix peut être `Null` dans ce cas, afficher un Call to Action "En profiter" à la place.
    
  * `travel`: [Travel Template.psd](psd/Travel%20Template.psd)
    * binding des properties `Title`, `Description`, `Price.Value`, `Price.Currency`, `Image.Url`, `Merchant.LogoUrl`. `Provider.LogoUrl`,
    * le prix peut être `Null` dans ce cas, afficher un Call to Action "En profiter" à la place.
    

Vous trouverez un exemple simple de template XAML [ici](src/Ividence.Programmatic.Renderer.Templates/SampleTemplate.xaml). Une fois terminé, faire une [pull request](https://github.com/ividence/programmatic-templates-starterkit/compare).

Bon courage :)
