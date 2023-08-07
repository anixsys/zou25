export default({$swal},inject)=>{
  inject('toaster',{
    show(message,status){
        const Toast = $swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
              toast.addEventListener('mouseenter', $swal.stopTimer)
              toast.addEventListener('mouseleave', $swal.resumeTimer)
            }
          })
          
          Toast.fire({
            icon: status,
            title: message
          })
          
     }
  });  

}