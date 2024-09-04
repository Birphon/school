package BoxToyFRI;

import java.math.*;
public class Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Box box = new Box();
		box.addToy(	"Teddy", 	Colors.YELLOW, 	new BigDecimal("12.34")			);
		box.addToy(	"Ratbert", 	Colors.RED, 	new BigDecimal(".000000000001")	);
		box.addToy(	"Pen", 		Colors.BLUE, 	new BigDecimal("34.56")			);
		
		System.out.println(box);
	}

}
