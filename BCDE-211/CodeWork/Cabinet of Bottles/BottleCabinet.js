var theCabinet = new Cabinet();
theCabinet.addBottle('Ardbeg', 'Scotch ', 'Single Malt', 10);
theCabinet.addBottle('Jim Beam Devil\'s Cut', 'Bourbon', 'Chared', 2);
theCabinet.addBottle('The Dead Rabbit', 'Irish Whiskey', 'visions of golden barley, and on the palate it\'s robust and spicy with black pepper', 3);
console.log(theCabinet.getAllMyBottles());
var elementMain = document.getElementsByTagName('main')[0];
elementMain.innerHTML += theCabinet.getAllMyBottles();
