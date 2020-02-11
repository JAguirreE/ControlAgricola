<template>
  <section id="FacturaDetalle">
    <div class="col-md-6 mb-md-0 mb-4">
      <h2 class="secondary-heading mb-3">
        Registrar Factura
      </h2>

      <p>
        Ingrese los datos solicitados para registrar una factura
      </p>
      <form class="form-horizontal" @submit.prevent="guardar">
        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1"
              >Número Factura</span
            >
          </div>
          <input
            type="text"
            placeholder="FV0001"
            class="form-control"
            v-model="objFactura.numero"
            required
          />
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Fecha</span>
          </div>
          <input
            type="date"
            class="form-control"
            v-model="objFactura.fecha"
            required
          />
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Emisor</span>
          </div>
          <input
            type="text"
            class="form-control"
            placeholder="Carlos Cardona"
            v-model="objFactura.emisor"
            required
          />
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Receptor</span>
          </div>
          <input
            type="text"
            class="form-control"
            placeholder="Antonio Aquiles"
            v-model="objFactura.receptor"
            required
          />
        </div>

        <button type="button" class="btn btn-primary" @click="addDetalle">
          + Detalle
        </button>
        <div v-for="(detalle, index) in detalles" :key="detalle.idDetFac">
          <div class="input-group mb-5">
            <div class="input-group mb-3">
              <div class="input-group-prepend">
                <span class="input-group-text" id="basic-addon1">Concepto</span>
              </div>
              <input
                type="text"
                v-model="detalle.concepto"
                class="form-control"
                required
              />
            </div>
            <div class="input-group-prepend">
              <span class="input-group-text" id="basic-addon1">Cantidad</span>
            </div>
            <input
              type="number"
              v-model="detalle.cantidad"
              class="form-control"
              required
            />
            <div class="input-group-prepend">
              <span class="input-group-text" id="basic-addon1"
                >Valor unidad</span
              >
            </div>
            <input
              type="number"
              v-model="detalle.valorUnidad"
              @change="getSubtotal(index)"
              @input="getSubtotal(index)"
              class="form-control"
              required
            />
            <div class="input-group-prepend">
              <span class="input-group-text">SubTotal</span>
            </div>
            <input
              type="number"
              v-model="detalle.subTotal"
              class="form-control"
              readonly
            />
          </div>
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text">Valor Base Imponible</span>
          </div>
          <input
            type="number"
            class="form-control"
            v-model="objFactura.valorBase"
            readonly
          />
        </div>

        <div class="input-group mb-3">
          <div class="input-group-text">
            <span class="input-group-prepend">Valor Impuestos</span>
          </div>
          <input
            type="number"
            class="form-control"
            v-model="objFactura.valorImpuestos"
            readonly
          />
        </div>

        <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text" id="basic-addon1">Total</span>
          </div>
          <input
            type="number"
            class="form-control"
            v-model="objFactura.valorTotal"
            readonly
          />
        </div>
        <div class="input-group mb-3">
          <button type="submit" class="btn btn-primary">
            Guardar
          </button>
        </div>
      </form>
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

import { Services, Notifications } from "../../index";

export default {
  name: "FacturacionDetalle",
  component: {
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
  watch: {
    $route: {
      immediate: true,
      handler(to, from) {
        if (to.params.idFac) {
          this.getFactura(to.params.idFac);
          this.getFacturaDetalles(to.params.idFac);
        }
      }
    }
  },
  data() {
    return {
      objFactura: {},
      detalles: []
    };
  },
  methods: {
    guardar() {
      let view = this;

      view.objFactura.detalles = this.detalles;
      Services.post("General/RegistrarFactura", this.objFactura)
        .then(res => {
          debugger;
          if (res) {
            view.objFactura = {
              ...view.objFactura,
              valorBase: res.valorBase,
              valorImpuestos: res.valorImpuestos,
              valorTotal: res.valorTotal,
              idFac: res.idFac
            };
          }
          Notifications.success("Operación exitosa");
          this.$router.push({ name: "Facturacion" });
        })
        .catch(err => {
          console.log(err);
        });
    },
    addDetalle() {
      this.detalles.push({});
    },

    getFactura(idFac) {
      Services.get("General/GetFactura", { idFactura: idFac })
        .then(res => {
          if (res) {
            this.objFactura = res;
          }
        })
        .catch(err => {
          Notifications.error(err);
        });
    },

    getFacturaDetalles(idFac) {
      Services.get("General/GetFacturaDetalleAll", { idFactura: idFac })
        .then(res => {
          if (res) {
            this.detalles = res;
          }
        })
        .catch(err => {
          Notifications.error(err);
        });
    },

    getSubtotal(index) {
      this.detalles[index].subTotal =
        this.detalles[index].cantidad * this.detalles[index].valorUnidad;
    }
  },
  mounted() {}
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
