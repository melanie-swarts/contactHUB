<template>
  <div>
    <label v-if="label">{{ label }}</label>
    <input :value="value" v-bind="$attrs" @input="updateValue">
  </div>
</template>

<script>
export default {
  name: 'BaseInput',
  inheritAttrs: false,
  props: {
    label: {
      type: String,
      default: ''
    },
    value: [String, Number]
  },
  methods: {
    updateValue(event) {
      this.$emit('input', event.target.value)
    }
  }
}
</script>
