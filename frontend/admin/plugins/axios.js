export default function ({ $axios, $swal,$router }) {
      $axios.onError(error => {
        console.log(error.response.status)
        if(error.response.status===403) {
          $swal("error","You do not have permissions to perform action","error")
        } 
        if(error.response.status===401) {
          $swal("error","UnAuthenticated Please Login","error")
           $router.push("/");
        }                 
      })
    }