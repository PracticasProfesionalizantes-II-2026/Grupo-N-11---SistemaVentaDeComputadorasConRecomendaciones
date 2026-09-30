(() => {
  const link=document.getElementById('admin-link'), form=document.getElementById('admin-login-form');
  if(!link||!form)return;
  const modal=new bootstrap.Modal(document.getElementById('admin-login-modal'));
  link.addEventListener('click',event=>{if(!localStorage.getItem('compumundo-admin')){event.preventDefault();modal.show()}});
  form.addEventListener('submit',async event=>{event.preventDefault();const f=new FormData(form),message=document.getElementById('admin-login-message');try{const response=await fetch('/tienda/admin/login',{method:'POST',headers:{'Content-Type':'application/json'},body:JSON.stringify({codigoAdmin:f.get('codigoAdmin'),contrasenia:f.get('contrasenia')})});if(!response.ok)throw Error();localStorage.setItem('compumundo-admin',JSON.stringify(await response.json()));window.location.assign(link.href)}catch{message.textContent='Código o contraseña incorrectos.'}});
})();
