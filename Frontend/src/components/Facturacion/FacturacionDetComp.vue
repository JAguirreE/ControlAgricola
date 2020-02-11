<template>
  <mdb-row>
    <label>Concepto</label>
    <input type="text" v-model="item.concepto" class="form-control" />
    <label>Cantidad</label>
    <input type="number" v-model="item.cantidad" class="form-control" />
    <label>Valor Unidad</label>
    <input type="number" v-model="item.valorUnidad" class="form-control" />
    <label>SubTotal</label>
    <input type="number" v-model="item.subTotal" class="form-control" />
  </mdb-row>
</template>

<script>
export default {
  name: "facdetcomp",
  props: {
    item: {
      type: Object,
      required: false,
      default: function() {
        return {};
      }
    }
  },
  watch: {
    item(item) {
      if (item) {
        this.itemSel = items;
      } else {
        this.itemSel = {};
      }
    }
  },
  data() {
    return {
      subtotal: 0
    };
  },
  components: {},
  mounted() {}
};
</script>
