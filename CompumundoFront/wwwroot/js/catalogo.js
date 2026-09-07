(() => {
  const grid = document.getElementById('products-grid'), status = document.getElementById('products-status'), search = document.getElementById('product-search');
  const cartItems = document.getElementById('cart-items'), cartCount = document.getElementById('cart-count'), modal = new bootstrap.Modal(document.getElementById('product-modal'));
  let products = [], cart = [], selectedProduct = null;
  const money = value => new Intl.NumberFormat('es-AR',{style:'currency',currency:'ARS',maximumFractionDigits:0}).format(value || 0);
  const iconFor = p => /mouse|teclado|auricular|monitor|gpu|placa/i.test(`${p.nombre} ${p.descripcion}`) ? '🧩' : '💻';
  const escapeHtml = value => String(value ?? '').replace(/[&<>'"]/g, c => ({'&':'&amp;','<':'&lt;','>':'&gt;',"'":'&#39;','"':'&quot;'}[c]));
  function renderProducts(){
    const term=search.value.trim().toLowerCase(), filtered=products.filter(p=>`${p.nombre} ${p.marca} ${p.modelo}`.toLowerCase().includes(term));
    grid.innerHTML=filtered.map(p=>`<article class="product-card"><div class="product-image">${iconFor(p)}</div><div class="product-info"><p class="product-brand">${escapeHtml(p.marca||'Tecnología')}</p><h3 class="product-name">${escapeHtml(p.nombre||'Producto sin nombre')}</h3><p class="product-description">${escapeHtml(p.modelo||p.descripcion||'Sin descripción disponible.')}</p><div class="product-footer"><strong class="product-price">${money(p.precio)}</strong><button class="detail-button" data-product-id="${p.id}">Ver detalle</button></div></div></article>`).join('');
    status.hidden=filtered.length>0; if(!filtered.length)status.textContent=term?'No encontramos productos con esa búsqueda.':'Todavía no hay productos cargados.';
  }
  function openDetail(id){
    selectedProduct=products.find(p=>p.id===Number(id)); if(!selectedProduct)return;
    document.getElementById('modal-product-icon').textContent=iconFor(selectedProduct); document.getElementById('modal-product-brand').textContent=selectedProduct.marca||'TECNOLOGÍA'; document.getElementById('modal-product-name').textContent=selectedProduct.nombre||'Producto'; document.getElementById('modal-product-description').textContent=selectedProduct.descripcion||selectedProduct.modelo||'Sin descripción disponible.'; document.getElementById('modal-product-stock').textContent=selectedProduct.stock>0?`Stock disponible: ${selectedProduct.stock}`:'Sin stock disponible'; document.getElementById('modal-product-price').textContent=money(selectedProduct.precio); document.getElementById('modal-add-button').disabled=selectedProduct.stock<=0; modal.show();
  }
  function renderCart(){
    cartCount.textContent=cart.reduce((t,p)=>t+p.quantity,0); if(!cart.length){cartItems.innerHTML='<p class="empty-cart">Todavía no agregaste productos.</p>';return;} cartItems.innerHTML=cart.map(p=>`<div class="cart-item"><strong>${escapeHtml(p.nombre)}</strong><p>${p.quantity} x ${money(p.precio)}</p><button data-remove-id="${p.id}">Quitar</button></div>`).join('');
  }
  grid.addEventListener('click',e=>{const b=e.target.closest('[data-product-id]');if(b)openDetail(b.dataset.productId)}); cartItems.addEventListener('click',e=>{const b=e.target.closest('[data-remove-id]');if(!b)return;cart=cart.filter(p=>p.id!==Number(b.dataset.removeId));renderCart()}); document.getElementById('modal-add-button').addEventListener('click',()=>{if(!selectedProduct||selectedProduct.stock<=0)return;const item=cart.find(p=>p.id===selectedProduct.id);if(item)item.quantity++;else cart.push({...selectedProduct,quantity:1});renderCart();modal.hide()}); search.addEventListener('input',renderProducts);
  fetch('/catalogo/productos').then(r=>{if(!r.ok)throw Error();return r.json()}).then(data=>{products=data;renderProducts()}).catch(()=>status.textContent='No pudimos cargar el catálogo. Iniciá el proyecto de APIs para ver los productos.');
})();
