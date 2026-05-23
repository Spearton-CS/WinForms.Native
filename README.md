# WinForms.Native
*As fast as Win32, as beautiful as .NET*

`WinForms.Native` is a high-performance, modular alternative to the legacy Windows Forms framework, rebuilt from the ground up for **.NET 10** and **Native AOT**. 

We are stripping away the bloat. No reflection, no hidden allocations, no legacy dependencies. Just raw, efficient interoperability with the Windows API, exposed through modern C# syntax.

---

### Core Philosophy

* **Native AOT First:** Designed specifically for ahead-of-time compilation. No dynamic code generation, no runtime surprises.
* **Zero Reflection:** The architecture relies on static type resolution. We bypass `System.Reflection` to eliminate startup overhead and footprint.
* **Minimal GC:** Memory management is explicit. We prioritize stack-allocated structures, `Span<T>`, and direct pointer manipulation over managed heap objects.
* **Modular Architecture:** We treat the Windows API as a set of decoupled components. Include only what you need, link only what you use.
* **Modern C#:** Leveraging the latest C# features (Ref Structs, `stackalloc`, `unsafe` contexts) to write code that looks clean but performs like native C/C++.

---

### Architecture

The project is structured into three distinct layers to ensure strict separation of concerns and binary stability:

1.  **PInvoke Layer (Foundation):** Direct, low-level mapping of Windows API functions. This is our source of truth for binary compatibility.
2.  **Safe Layer (Abstraction):** Wrappers that handle type-safety and resource lifecycle management without hiding the underlying native behavior.
3.  **Core (Orchestration):** High-level interfaces that provide the "beautiful" developer experience while maintaining strict control over native resources.

*[Dependency Graph SVG/PNG here later]*

---

### Why build this?

Standard WinForms is a legacy monolith that drags along decades of baggage.
It forces unnecessary dependencies (like `System.Drawing` with its GDI+ baggage)
that make Native AOT deployments nearly impossible and binary sizes massive. 

`WinForms.Native` is built for engineers who need:
- Sub-millisecond startup times.
- Small memory footprint.
- Full access to the Win32 API without fighting the framework.

---

### Status: Early Alpha (Foundation Layer)

We are currently in the **foundation stage**. 
* **Current focus:** Building a robust, type-safe `Unsafe` layer to cover the core Windows API primitives.
* **Completeness:** ~10% (Default WndProc covered base message types, GDI and GDI+ able to draw simple UI, ...)
* **Goal:** Establish the architecture for the `Safe` wrappers and the windowing engine.

---

### Contributing

This project is for engineers who care about system-level performance.
If you understand why manual memory management in C# is a feature, not a bug,
and you want to help us replace the legacy WinForms stack — join us.

---

*License: MIT*