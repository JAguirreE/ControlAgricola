<template>
  <section id="profile">
    <div data-v-7a55ccee="" class="mt-5 row" data-v-4bc16661="">
      <div class="mb-md-0 mb-4 col-md-6" data-v-7a55ccee="">
        <h2 class="secondary-heading mb-3">
          Registrar Actividad
        </h2>
        <p>
          Ingrese los datos de la actividad
        </p>
        <section class="preview">
          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <label for="inputGroupSelect01" class="input-group-text"
                >Tipo actividad</label
              >
            </div>
            <select
              id="inputGroupSelect01"
              class="browser-default custom-select"
              ><option selected="selected">Seleccione...</option
              ><option value="1">One</option
              ><option value="2">Two</option
              ><option value="3">Three</option></select
            >
          </div>

          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <label for="inputGroupSelect01" class="input-group-text"
                >Meteorología</label
              >
            </div>
            <select
              id="inputGroupSelect01"
              class="browser-default custom-select"
              ><option selected="selected">Seleccione...</option
              ><option value="1">One</option
              ><option value="2">Two</option
              ><option value="3">Three</option></select
            >
          </div>

          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <label for="inputGroupSelect01" class="input-group-text"
                >Producto utilizado</label
              >
            </div>
            <select
              id="inputGroupSelect01"
              class="browser-default custom-select"
              ><option selected="selected">Seleccione...</option
              ><option value="1">One</option
              ><option value="2">Two</option
              ><option value="3">Three</option></select
            >
          </div>

          <div class="input-group mb-3">
            <div class="input-group-prepend">
              <label for="inputGroupSelect01" class="input-group-text"
                >Cantidad de producto</label
              >
            </div>
            <input type="number" step="0.1" min="0" />
          </div>

          <div class="text-center">
            <button class="btn btn-default ripple-parent">
              Guardar
            </button>
          </div>
        </section>
      </div>
    </div>
  </section>
</template>

<script>
import {
  mdbRow,
  mdbCol,
  mdbCard,
  mdbCardBody,
  mdbView,
  mdbMask,
  mdbCardTitle,
  mdbCardText,
  mdbCardFooter,
  mdbIcon,
  mdbBtn,
  mdbPagination,
  mdbPageNav,
  mdbPageItem
} from "mdbvue";

export default {
  name: "Profile",
  components: {
    mdbRow,
    mdbCol,
    mdbCard,
    mdbCardBody,
    mdbView,
    mdbMask,
    mdbCardTitle,
    mdbCardText,
    mdbCardFooter,
    mdbIcon,
    mdbBtn,
    mdbPagination,
    mdbPageNav,
    mdbPageItem
  },
  data() {
    return {};
  }
};
</script>

<style scoped>
.profile-card-footer {
  background-color: #f7f7f7 !important;
  padding: 1.25rem;
}
.card.card-cascade .view {
  box-shadow: 0 3px 10px 0 rgba(0, 0, 0, 0.15), 0 3px 12px 0 rgba(0, 0, 0, 0.15);
}
</style>
