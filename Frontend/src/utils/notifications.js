import Swal from "sweetalert2"

export class Notifications {

  static success (text, type) {
    Swal.fire({
      title: 'Info',
      text: text,
      type: type,
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
