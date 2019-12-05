import Swal from "sweetalert2"

export class Notifications {

  static success (text) {
    Swal.fire({
      title: 'Info',
      text: text,
      icon: 'success',
      allowOutsideClick: true,
      confirmButtonText: "Ok"
    });
  }

  static error (text) {
    Swal.fire({
      title: 'Error',
      text: text,
      type: 'error',
      confirmButtonText: "Ok"
    });
  }
}
