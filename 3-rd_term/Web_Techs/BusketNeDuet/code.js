const main_products_list = document.querySelector('.main_products');
const main_view = document.querySelector('.main_view');
const main_cart_list = document.querySelector('.main_view_box');

let products = [
	{
		id: 0,
		name_product: 'Smoothie',
		price_product: 50,
		img_src: 'smoothie.jpeg',
		count: 0		
	},
	{
		id: 1,
		name_product: 'Mango',
		price_product: 75,
		img_src: 'mango.png',		
		count: 0
	},
	{
		id: 2,
		name_product: 'Chak chak',
		price_product: 100,
		img_src: 'chakchak.jpg',	
		count: 0	
	}
];
let cart = [];

function itemProduct(product) {
	return `<div class="main_products_item" draggable='true' ondragstart=setDraggedIndex(${product.id})>
		<p>${product.name_product}</p>
		<p>${product.price_product}</p>
		<img src="images/${product.img_src}">
		<button onclick="addProduct(${product.id})">Add product</button>
	</div>`;
}

function allProducts(products) {
	main_products_list.innerHTML = '<h2 class="main_products_item_title">Products</h2>';
	for (item of products){
		main_products_list.innerHTML += itemProduct(item);
	}
}

function itemCart(product) {
	return `<div class="main_view_box_item" draggable='true' ondragstart=setDraggedIndex(${product.id})>
		<p>${product.name_product}</p>
		<p>${product.price_product}</p>
		<img src="images/${product.img_src}">
		<p>${product.count}</p>
		<button onclick="addProduct(${product.id})">Add product</button>
		<button onclick="deleteProduct(${product.id})">Remove product</button>
	</div>`;
}

function statusCart(pricer, countr) {
	return `<div class="statusCart">
		<p>Products amount: ${countr}</p>
		<p>General price: ${pricer}</p>
	</div>`;
}

function PrintAllBasket() {
	main_cart_list.innerHTML = '';

	let countProducts = 0;
	let priceProduct = 0;

	if (cart.length != 0)
	{
		for (item of products){
				countProducts = countProducts + item.count;
				priceProduct = priceProduct + item.price_product * item.count;
		}
	}
	if (cart.length != 0)
	{
		for (item of products){
			if(item.count > 0)
				main_cart_list.innerHTML += itemCart(item);
		}
	}
	if (countProducts != 0){
		main_cart_list.innerHTML += statusCart(priceProduct, countProducts);
	}

}

function addProduct(id) {
	let cartItem = products[id];
	cartItem.count++;
	cart.push(cartItem);
	let tempCart = new Set(cart);
   	cart = Array.from(tempCart);

	PrintAllBasket();
}

function deleteProduct(id){
	let cartItem = products[id];
	cartItem.count--;
	let tempCart = new Set(cart);
	cart = Array.from(tempCart);
	for (let i = 0; i < cart.length; i++)
	{
		if(cart[i].count == 0)
		{
			cart.splice(i, 1);
		}
	}
	PrintAllBasket();
}

let draggedIndex = 0;

const setDraggedIndex = (index) => {
	draggedIndex = index;
}

var is_destination_to_cart = false;
var is_destination_to_products = false;

main_cart_list.addEventListener('dragstart', (evt)=>{
	is_destination_to_cart = false;
	is_destination_to_products = true;
	evt.target.classList.add('selected');
})

main_cart_list.addEventListener('dragover', (evt)=> {
	evt.preventDefault();
	evt.target.classList.add('selected');
});

main_cart_list.addEventListener('drop', (evt)=> {
	evt.preventDefault();
	if (is_destination_to_cart){
		addProduct(draggedIndex);
	}
});

main_cart_list.addEventListener('dragend', (evt)=>{
    evt.target.classList.add('selected');
})


main_products_list.addEventListener('dragstart', (evt)=>{
	is_destination_to_cart = true;
	is_destination_to_products = false;
	evt.target.classList.add('selected');
})

main_products_list.addEventListener('dragover', (evt)=> {
	evt.preventDefault();
	evt.target.classList.add('selected');
});

main_products_list.addEventListener('drop', (evt)=> {
	evt.preventDefault();
	if (is_destination_to_products){
		cart.splice(draggedIndex, 1);
		products[draggedIndex].count=0;
		PrintAllBasket();
	}
});

main_products_list.addEventListener('dragend', (evt)=>{
    evt.target.classList.add('selected');
})

window.addEventListener('load', allProducts(products));